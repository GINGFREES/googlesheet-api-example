using google_sheet_api_service.Models.Utils;
namespace google_sheet_api_service.Models
{
    public class Character : ModelBase<Character>
    {
        public int Id { get; set; }
        public int gId { get; set; }
        public string name { get; set; }
        public int islandGid { get; set; }
        public int unlockedBuildingGid { get; set; }
        public string unlockedBuildingName { get; set; }
        public int unlockedBuildingLevel { get; set; }
        public string nameKey { get; set; }
        public string descriptionKey { get; set; }
        public string imageKey { get; set; }

        public Character()
            => (
                this.Id,
                this.gId,
                this.name,
                this.islandGid,
                this.unlockedBuildingGid,
                this.unlockedBuildingName,
                this.unlockedBuildingLevel,
                this.nameKey,
                this.descriptionKey,
                this.imageKey
            )
            = (
                -1,
                -1,
                string.Empty,
                -1,
                -1,
                string.Empty,
                -1,
                string.Empty,
                string.Empty,
                string.Empty
            );

        public Character(int index, IList<Object> row)
            => (
                this.Id,
                this.gId,
                this.name,
                this.islandGid,
                this.unlockedBuildingGid,
                this.unlockedBuildingName,
                this.unlockedBuildingLevel,
                this.nameKey,
                this.descriptionKey,
                this.imageKey
            )
            = (
                index,
                row.Count <= 1 ? -1 : Convert.ToInt32(row[0]),
                row.Count <= 2 ? string.Empty : Convert.ToString(row[1]) ?? string.Empty,
                row.Count <= 3 ? -1 : Convert.ToInt32(row[2]),
                row.Count <= 4 ? -1 : Convert.ToInt32(row[3]),
                row.Count <= 5 ? string.Empty : Convert.ToString(row[4]) ?? string.Empty,
                row.Count <= 6 ? -1 : Convert.ToInt32(row[5]),
                row.Count <= 7 ? string.Empty : Convert.ToString(row[6]) ?? string.Empty,
                row.Count <= 8 ? string.Empty : Convert.ToString(row[7]) ?? string.Empty,
                row.Count <= 9 ? string.Empty : Convert.ToString(row[8]) ?? string.Empty
            );

        public Character GetModel(int index, IList<Object> row)
            => new Character(index, row);
    }
}