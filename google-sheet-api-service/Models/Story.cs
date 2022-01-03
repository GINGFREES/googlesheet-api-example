using google_sheet_api_service.Models.Utils;
namespace google_sheet_api_service.Models
{
    public class Story : ModelBase<Story>
    {
        public int Id { get; set; }
        public int gId { get; set; }
        public string stroyName { get; set; }
        public int characterGid { get; set; }
        public string characterName { get; set; }
        public string buildingName { get; set; }
        public int buildingLevel { get; set; }
        public int buildingGid { get; set; }

        public Story()
        => (
            this.Id,
            this.gId,
            this.stroyName,
            this.characterGid,
            this.characterName,
            this.buildingName,
            this.buildingLevel,
            this.buildingGid
        )
        = (
            -1,
            -1,
            string.Empty,
            -1,
            string.Empty,
            string.Empty,
            -1,
            -1
        );

        public Story(int index, IList<Object> row)
        => (
            this.Id,
            this.gId,
            this.stroyName,
            this.characterGid,
            this.characterName,
            this.buildingName,
            this.buildingLevel,
            this.buildingGid
        )
        = (
            index,
            row.Count <= 0 ? -1 : Convert.ToInt32(row[0]),
            row.Count <= 1 ? string.Empty : Convert.ToString(row[1]) ?? string.Empty,
            row.Count <= 2 ? -1 : Convert.ToInt32(row[2]),
            row.Count <= 3 ? string.Empty : Convert.ToString(row[3]) ?? string.Empty,
            row.Count <= 4 ? string.Empty : Convert.ToString(row[4]) ?? string.Empty,
            row.Count <= 5 ? -1 : Convert.ToInt32(row[5]),
            row.Count <= 6 ? -1 : Convert.ToInt32(row[6])
        );

        public Story GetModel(int index, IList<Object> row)
            => new Story(index, row);
    }
}