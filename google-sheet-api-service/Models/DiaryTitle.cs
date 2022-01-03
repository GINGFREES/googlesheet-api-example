using google_sheet_api_service.Models.Utils;
namespace google_sheet_api_service.Models
{
    public class DiaryTitle : ModelBase<DiaryTitle>
    {
        public int Id { get; set; }
        public string diaryTitleName { get; set; }
        public string diaryTitleKey { get; set; }

        public DiaryTitle()
            => (
                this.Id,
                this.diaryTitleKey,
                this.diaryTitleName
            )
            = (
                -1,
                string.Empty,
                string.Empty
            );

        public DiaryTitle(int index, IList<Object> row)
            => (
                this.Id,
                this.diaryTitleKey,
                this.diaryTitleName
            )
            = (
                index,
                row.Count <= 0 ? string.Empty : Convert.ToString(row[0]) ?? string.Empty,
                row.Count <= 1 ? string.Empty : Convert.ToString(row[1]) ?? string.Empty
            );

        public DiaryTitle GetModel(int index, IList<Object> row)
            => new DiaryTitle(index, row);
    }
}