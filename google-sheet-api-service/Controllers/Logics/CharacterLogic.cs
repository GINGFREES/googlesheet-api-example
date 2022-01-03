using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using google_sheet_api_service.Models;
using Newtonsoft.Json;
namespace google_sheet_api_service.Controllers.Logics
{
    public class CharacterLogic : IModelLogic
    {
        public List<Character> RequestCharacterLogicData()
        {
            Character character = new Character();
            List<Character> list = this.RequestModelList<Character>(
                "人物",
                "A2",
                "I",
                character.GetModel
            );
            return list;
        }
    }
}