using google_sheet_api_service.Models;
namespace google_sheet_api_service.Controllers.Logics
{
    public class IslandLogic : IModelLogic
    {
        public List<Island> RequestIslandData()
        {
            Island island = new Island();
            List<Island> list = this.RequestModelList<Island>(
                "小島",
                "A2",
                "I",
                island.GetModel
            );
            return list;
        }
    }
}