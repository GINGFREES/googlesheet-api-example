using google_sheet_api_service.Models;
namespace google_sheet_api_service.Controllers.Logics
{
    public class BuildingAnimSettingLogic : IModelLogic
    {
        public List<BuildingAnimSetting> RequestBuildingAnimSettingData()
        {
            BuildingAnimSetting buildingAnimSetting = new BuildingAnimSetting();
            List<BuildingAnimSetting> list = this.RequestModelList<BuildingAnimSetting>(
                "建築動畫",
                "J2",
                "M",
                buildingAnimSetting.GetModel
            );
            return list;
        }
    }
}