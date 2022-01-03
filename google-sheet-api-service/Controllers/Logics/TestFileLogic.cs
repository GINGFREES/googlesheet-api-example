using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace google_sheet_api_service.Controllers.Logics
{
    public class TestFileLogic
    {
        private static readonly string[] Scopes =
            {SheetsService.Scope.SpreadsheetsReadonly};
        private static readonly string ApplicationName =
            "Test GoogleSheet Api Service";

        public string RequestGoolgSheetApi()
        {
            string result = string.Empty;
            GoogleCredential googleCredential;

            string credPath = "token.json";
            googleCredential = GoogleCredential
                .FromFileAsync("./credentials.json", CancellationToken.None)
                .Result.CreateScoped(Scopes);
            Console.WriteLine("Credential file saved to: " + credPath);

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = googleCredential,
                ApplicationName = ApplicationName,
            });

            // Define request parameters.
            String spreadsheetId = "1SlWdALuI-fN9XBBF6jJe8C83saN7fCUTeOexw2HVZ-k";
            String range = "TestFile!A2:E";

            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            // Prints the names and majors of students in a sample spreadsheet:
            // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                result += "Test1, Test2, Test3, Test4, Test5\n";
                // Console.WriteLine("Test1, Test2, Test3, Test4, Test5");
                foreach (var row in values)
                {
                    // Print columns A and E, which correspond to indices 0 and 4.
                    // Console.WriteLine($"{row[0]}, {row[1]}, {row[2]}, {row[3]}, {row[4]}");
                    result += $"{row[0]}, {row[1]}, {row[2]}, {row[3]}, {row[4]}\n";
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }

            return result;
        }
    }
}