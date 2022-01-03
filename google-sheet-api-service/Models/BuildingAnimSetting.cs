using System.Collections.Specialized;
using System.Text;
using System.Data;
using System;
using Microsoft.VisualBasic.CompilerServices;
using google_sheet_api_service.Models.Utils;
namespace google_sheet_api_service.Models
{
    public class BuildingAnimSetting : ModelBase<BuildingAnimSetting>
    {
        public int Id { get; set; }
        public string buildingSize { get; set; }
        public string levelUpAnimName { get; set; }
        public string checkAnimValue { get; set; }
        public string levelUpAnimValue { get; set; }

        public BuildingAnimSetting()
            => (
                this.Id,
                this.buildingSize,
                this.levelUpAnimName,
                this.checkAnimValue,
                this.levelUpAnimValue
            )
            = (
                -1,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty
            );

        public BuildingAnimSetting(int index, IList<Object> row)
            => (
                this.Id,
                this.buildingSize,
                this.levelUpAnimName,
                this.checkAnimValue,
                this.levelUpAnimValue
            )
            = (
                index,
                row.Count <= 0 ? string.Empty : Convert.ToString(row[0]) ?? string.Empty,
                row.Count <= 1 ? string.Empty : Convert.ToString(row[1]) ?? string.Empty,
                row.Count <= 2 ? string.Empty : Convert.ToString(row[2]) ?? string.Empty,
                row.Count <= 3 ? string.Empty : Convert.ToString(row[3]) ?? string.Empty
            );

        public BuildingAnimSetting GetModel(int index, IList<Object> row)
            => new BuildingAnimSetting(index, row);
    }
}