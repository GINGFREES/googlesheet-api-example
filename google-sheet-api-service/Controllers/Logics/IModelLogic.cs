using google_sheet_api_service.Models.Utils;
namespace google_sheet_api_service.Controllers.Logics
{
    public interface IModelLogic
    {
    }

    public static class IModelLogicExtensions
    {
        public static List<T> RequestModelList<T>(
            this IModelLogic self,
            string sheetName,
            string keyStart,
            string keyEnd,
            Func<int, IList<Object>, T> getter) where T : ModelBase<T>
        {
            IList<IList<Object>> datas =
                GoogleSheetApiLogic.RequestGoolgSheetApi(sheetName, keyStart, keyEnd);

            List<T> list = new List<T>();
            if (getter == null)
            {
                Console.WriteLine("No getter");
                return list;
            }
            if (datas != null && datas.Count > 0)
            {
                int index = 0;
                foreach (var row in datas)
                {
                    T target = getter(++index, row);
                    list.Add(target);
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }

            return list;
        }
    }
}