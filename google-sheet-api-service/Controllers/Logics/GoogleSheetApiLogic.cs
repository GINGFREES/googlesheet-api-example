using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using google_sheet_api_service.Models;
using Newtonsoft.Json;
namespace google_sheet_api_service.Controllers.Logics
{
    public class GoogleSheetApiLogic
    {
        private static readonly string[] Scopes =
        {SheetsService.Scope.SpreadsheetsReadonly};
        private static readonly string ApplicationName =
            "Test GoogleSheet Api Service";
        public static IList<IList<Object>> RequestGoolgSheetApi(string sheetName, string keyStart, string keyEnd)
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
            String spreadsheetId = "1kIczpmNrmNtrN_5C8Qq5ciUnpjPMdlcrMXxN5oy_1Qc";
            String range = $"{sheetName}!{keyStart}:{keyEnd}";

            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            // Prints the names and majors of students in a sample spreadsheet:
            // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit
            ValueRange response = request.Execute();
            return response.Values;

        }

    }
}