using System.Globalization;
using google_sheet_api_service.Models.Utils;
namespace google_sheet_api_service.Models
{
    public class Diary : ModelBase<Diary>
    {
        public int Id { get; set; }
        public int gId { get; set; }
        public string name { get; set; }
        public int characterGid { get; set; }
        public string characterName { get; set; }
        public string diaryTitleKey { get; set; }
        public string diaryContentKey { get; set; }

        public Diary()
         => (
             this.Id,
             this.gId,
             this.name,
             this.characterGid,
             this.characterName,
             this.diaryTitleKey,
             this.diaryContentKey)
        = (
            -1,
            -1,
            string.Empty,
            -1,
            string.Empty,
            string.Empty,
            string.Empty
        );

        public Diary(int index, IList<Object> row)
            => (
                this.Id,
                this.gId,
                this.name,
                this.characterGid,
                this.characterName,
                this.diaryTitleKey,
                this.diaryContentKey
            )
            = (
                index,
                row.Count <= 0 ? -1 : Convert.ToInt32(row[0]),
                row.Count <= 1 ? string.Empty : Convert.ToString(row[1]) ?? string.Empty,
                row.Count <= 2 ? -1 : Convert.ToInt32(row[2]),
                row.Count <= 3 ? string.Empty : Convert.ToString(row[3]) ?? string.Empty,
                row.Count <= 4 ? string.Empty : Convert.ToString(row[4]) ?? string.Empty,
                row.Count <= 5 ? string.Empty : Convert.ToString(row[5]) ?? string.Empty
            );

        public Diary GetModel(int index, IList<Object> row)
            => new Diary(index, row);
    }
}