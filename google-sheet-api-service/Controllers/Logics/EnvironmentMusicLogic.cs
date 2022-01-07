using google_sheet_api_service.Models;
using google_sheet_api_service.Models.Utils;
namespace google_sheet_api_service.Controllers.Logics
{
    public class EnvironmentMusicLogic : IModelLogic
    {
        public List<EnvironmentMusic> RequestEnvironmentMusic()
        {
            EnvironmentMusic environmentMusic =
                new EnvironmentMusic();
            return this.RequestModelList<EnvironmentMusic>(
                "小島環境音",
                "A2",
                "J",
                environmentMusic.GetModel
            );
        }
    }
}