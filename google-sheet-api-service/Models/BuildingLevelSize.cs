using System.ComponentModel;
using System.Text;
using System;
using System.Globalization;
using google_sheet_api_service.Models.Utils;
namespace google_sheet_api_service.Models
{
    public class BuildingLevelSize : ModelBase<BuildingLevelSize>
    {
        public int Id { get; set; }
        public string buildingName { get; set; }
        public int buildingLevel { get; set; }
        public int islandGid { get; set; }
        public int buildingGid { get; set; }
        public string checkAnim { get; set; }
        public string levelUpAnim { get; set; }
        public string buildingSize { get; set; }

        public BuildingLevelSize() : base()
            => (
              this.Id,
              this.buildingName,
              this.buildingLevel,
              this.islandGid,
              this.buildingGid,
              this.checkAnim,
              this.levelUpAnim,
              this.buildingSize
            )
            = (
                -1,
                string.Empty,
                -1,
                -1,
                -1,
                string.Empty,
                string.Empty,
                string.Empty
            );

        public BuildingLevelSize(int index, IList<Object> row)
            => (
                this.Id,
                this.buildingName,
                this.buildingLevel,
                this.islandGid,
                this.buildingGid,
                this.checkAnim,
                this.levelUpAnim,
                this.buildingSize
            )
            = (
                index,
                row.Count <= 0 ? string.Empty : Convert.ToString(row[0]) ?? string.Empty,
                row.Count <= 1 ? -1 : Convert.ToInt32(row[1]),
                row.Count <= 2 ? -1 : Convert.ToInt32(row[2]),
                row.Count <= 3 ? -1 : Convert.ToInt32(row[3]),
                row.Count <= 4 ? string.Empty : Convert.ToString(row[4]) ?? string.Empty,
                row.Count <= 5 ? string.Empty : Convert.ToString(row[5]) ?? string.Empty,
                row.Count <= 6 ? string.Empty : Convert.ToString(row[6]) ?? string.Empty
            );

        public BuildingLevelSize GetModel(int index, IList<Object> row)
            => new BuildingLevelSize(index, row);
    }
}