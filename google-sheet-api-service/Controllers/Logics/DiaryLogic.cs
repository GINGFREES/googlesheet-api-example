using google_sheet_api_service.Models;
namespace google_sheet_api_service.Controllers.Logics
{
    public class DiaryLogic : IModelLogic
    {
        public List<Diary> RequestDiaryData()
        {
            Diary diary = new Diary();
            List<Diary> list = this.RequestModelList<Diary>(
                "日記",
                "A2",
                "F",
                diary.GetModel
            );
            return list;
        }
    }
}