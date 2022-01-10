using google_sheet_api_service.Models;
namespace google_sheet_api_service.Controllers.Logics
{
    public class SoundSettingLogic : IModelLogic
    {
        public List<SoundSetting> RequestSoundSettingData()
        {
            SoundSetting soundSetting = new SoundSetting();
            return this.RequestModelList<SoundSetting>(
                "小島音效設置",
                "A2",
                "H",
                soundSetting.GetModel
            );
        }
    }
}