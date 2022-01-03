using System;
using google_sheet_api_service.Models.Utils;
namespace google_sheet_api_service.Models
{
    public class Building : ModelBase<Building>
    {
        public int Id { get; set; }
        public int gId { get; set; }
        public string name { get; set; }
        public string islandGid { get; set; }
        public string islandName { get; set; }
        public int maxLevel { get; set; }
        public string imageKey { get; set; }
        public string buildingNameKey { get; set; }
        public string buildingDescriptionKey { get; set; }
        public string alreadySettingBuildingLevelCount { get; set; }
        public Building()
        {
            Id = -1;
            gId = -1;
            name = string.Empty;
            islandGid = string.Empty;
            islandName = string.Empty;
            maxLevel = -1;
            imageKey = string.Empty;
            buildingNameKey = string.Empty;
            buildingDescriptionKey = string.Empty;
            alreadySettingBuildingLevelCount = string.Empty;
        }

        public Building(int index, IList<Object> row)
        {
            Id = index;
            gId = row.Count <= 0 ? -1 : Convert.ToInt32(row[0]);
            name = row.Count <= 1 ? string.Empty : Convert.ToString(row[1]) ?? string.Empty;
            islandGid = row.Count <= 2 ? string.Empty : Convert.ToString(row[2]) ?? string.Empty;
            islandName = row.Count <= 3 ? string.Empty : Convert.ToString(row[3]) ?? string.Empty;
            maxLevel = row.Count <= 4 ? -1 : Convert.ToInt32(row[4]);
            imageKey = row.Count <= 5 ? string.Empty : Convert.ToString(row[5]) ?? string.Empty;
            buildingNameKey = row.Count <= 6 ? string.Empty : Convert.ToString(row[6]) ?? string.Empty;
            buildingDescriptionKey = row.Count <= 7 ? string.Empty : Convert.ToString(row[7]) ?? string.Empty;
            alreadySettingBuildingLevelCount = row.Count <= 8 ? string.Empty : Convert.ToString(row[8]) ?? string.Empty;
        }

        public Building GetModel(int index, IList<Object> row)
            => new Building(index, row);

    }
}