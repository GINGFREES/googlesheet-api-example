
using google_sheet_api_service.Models;
namespace google_sheet_api_service.Controllers.Logics
{
    public class BuildingLevelSizeLogic : IModelLogic
    {
        public List<BuildingLevelSize> RequestBuildingLevelSizeData()
        {
            BuildingLevelSize buildingLevelSize = new BuildingLevelSize();
            List<BuildingLevelSize> list =
                this.RequestModelList(
                    "建築動畫",
                    "A2",
                    "G",
                    buildingLevelSize.GetModel
                );
            return list;
        }

    }
}