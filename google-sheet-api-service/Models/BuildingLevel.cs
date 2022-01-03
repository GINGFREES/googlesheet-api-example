using google_sheet_api_service.Models.Utils;
namespace google_sheet_api_service.Models
{
    public class BuildingLevel : ModelBase<BuildingLevel>
    {
        public int Id { get; set; }
        public string buildingName { get; set; }
        public int buildingLevel { get; set; }

        public BuildingLevel()
        => (this.Id, this.buildingName, this.buildingLevel) = (-1, string.Empty, -1);

        public BuildingLevel(int index, IList<Object> row)
        => (this.Id, this.buildingName, this.buildingLevel) =
        (index, row.Count <= 0 ? string.Empty : Convert.ToString(row[0])
            ?? string.Empty, Convert.ToInt32(row[1]));

        public BuildingLevel GetModel(int index, IList<Object> row)
            => new BuildingLevel(index, row);
    }
}