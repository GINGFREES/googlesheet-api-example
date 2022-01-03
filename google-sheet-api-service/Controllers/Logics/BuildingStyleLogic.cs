using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using google_sheet_api_service.Models;
using Newtonsoft.Json;

namespace google_sheet_api_service.Controllers.Logics
{
    public class BuildingStyleLogic : IModelLogic
    {
        public List<BuildingStyle> RequestBuildingStyleData()
        {
            BuildingStyle buildingStyle = new BuildingStyle();
            List<BuildingStyle> list = this.RequestModelList<BuildingStyle>(
                "建築造型",
                "A2",
                "G",
                buildingStyle.GetModel
            );

            return list.ToList();
        }

    }
}