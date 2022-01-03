using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using google_sheet_api_service.Models;
using Newtonsoft.Json;

namespace google_sheet_api_service.Controllers.Logics
{
    public class BuildingLevelLogic : IModelLogic
    {
        public List<BuildingLevel> RequestBuildingLevelData()
        {
            BuildingLevel buildingLevel = new BuildingLevel();
            List<BuildingLevel> list =
                this.RequestModelList(
                    "建築等級",
                    "A2",
                    "B",
                    buildingLevel.GetModel
                );
            return list;
        }
    }
}