using google_sheet_api_service.Models.Utils;
namespace google_sheet_api_service.Models
{
    public class BuildingStyle : ModelBase<BuildingStyle>
    {
        public int Id { get; set; }
        public int gId { get; set; }
        public string buildingStyleName { get; set; }
        public int islandGid { get; set; }
        public int buildingGid { get; set; }
        public string buildingName { get; set; }
        public int minLevel { get; set; }
        public string imageKey { get; set; }

        public BuildingStyle()
            => (
                this.Id,
                this.gId,
                this.buildingStyleName,
                this.islandGid,
                this.buildingGid,
                this.buildingName,
                this.minLevel,
                this.imageKey
            )
            =
            (
                -1,
                -1,
                string.Empty,
                -1,
                -1,
                string.Empty,
                -1,
                string.Empty
            );

        public BuildingStyle(int index, IList<Object> row)
            => (
                this.Id,
                this.gId,
                this.buildingStyleName,
                this.islandGid,
                this.buildingGid,
                this.buildingName,
                this.minLevel,
                this.imageKey
            )
            = (
                index,
                row.Count <= 0 ? -1 : Convert.ToInt32(row[0]),
                row.Count <= 1 ? string.Empty : Convert.ToString(row[1]) ?? string.Empty,
                row.Count <= 2 ? -1 : Convert.ToInt32(row[2]),
                row.Count <= 3 ? -1 : Convert.ToInt32(row[3]),
                row.Count <= 4 ? string.Empty : Convert.ToString(row[4]) ?? string.Empty,
                row.Count <= 5 ? -1 : Convert.ToInt32(row[5]),
                row.Count <= 6 ? string.Empty : Convert.ToString(row[6]) ?? string.Empty
            );

        public BuildingStyle GetModel(int index, IList<Object> row)
            => new BuildingStyle(index, row);
    }
}