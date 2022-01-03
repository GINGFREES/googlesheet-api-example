using google_sheet_api_service.Models;
namespace google_sheet_api_service.Controllers.Logics
{
    public class StoryLogic : IModelLogic
    {
        public List<Story> RequestStoryData()
        {
            Story story = new Story();
            List<Story> list = this.RequestModelList<Story>(
                "事件",
                "A2",
                "G",
                story.GetModel
            );
            return list;
        }
    }
}