using google_sheet_api_service.Models;
namespace google_sheet_api_service.Controllers.Logics
{
    public class StoryDialogueLogic : IModelLogic
    {
        public List<StoryDialogue> RequestStoryDialogueData()
        {
            StoryDialogue storyDialogue = new StoryDialogue();
            List<StoryDialogue> list = this.RequestModelList<StoryDialogue>(
                "事件對話",
                "A2",
                "J",
                storyDialogue.GetModel
            );

            return list;
        }
    }
}