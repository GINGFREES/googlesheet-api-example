using google_sheet_api_service.Models;
namespace google_sheet_api_service.Controllers.Logics
{
    public class DiaryTitleLogic : IModelLogic
    {
        public List<DiaryTitle> RequestDiaryTitleData()
        {
            DiaryTitle title = new DiaryTitle();
            List<DiaryTitle> list = this.RequestModelList<DiaryTitle>(
                "日記",
                "I2",
                "J",
                title.GetModel
            );
            return list;
        }
    }
}