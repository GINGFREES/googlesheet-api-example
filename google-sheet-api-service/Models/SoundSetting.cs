using google_sheet_api_service.Models.Utils;
namespace google_sheet_api_service.Models
{
    public class SoundSetting : ModelBase<SoundSetting>
    {
        public int Id { get; set; }
        public int islandGid { get; set; }
        public string islandName { get; set; }
        public double bgmVolume { get; set; }
        public double windVolume { get; set; }
        public double waveVolume { get; set; }
        public double birdVolume { get; set; }
        public double lakeVolume { get; set; }
        public double bellVolume { get; set; }

        public SoundSetting()
            => (
                this.Id,
                this.islandGid,
                this.islandName,
                this.bgmVolume,
                this.windVolume,
                this.waveVolume,
                this.birdVolume,
                this.lakeVolume,
                this.bellVolume
            )
            = (
                -1,
                -1,
                string.Empty,
                0f,
                0f,
                0f,
                0f,
                0f,
                0f
            );

        public SoundSetting(int index, IList<Object> row)
        => (
                this.Id,
                this.islandGid,
                this.islandName,
                this.bgmVolume,
                this.windVolume,
                this.waveVolume,
                this.birdVolume,
                this.lakeVolume,
                this.bellVolume
            )
            = (
                index,
                row.Count <= 0 ? -1 : Convert.ToInt32(row[0]),
                row.Count <= 1
                    ? string.Empty
                    : Convert.ToString(row[1]) ?? string.Empty,
                row.Count <= 2
                    ? 0f
                    : StringToDouble(Convert.ToString(row[2]) ?? string.Empty),
                row.Count <= 3
                    ? 0f
                    : StringToDouble(Convert.ToString(row[3]) ?? string.Empty),
                row.Count <= 4
                    ? 0f
                    : StringToDouble(Convert.ToString(row[4]) ?? string.Empty),
                row.Count <= 5
                    ? 0f
                    : StringToDouble(Convert.ToString(row[5]) ?? string.Empty),
                row.Count <= 6
                    ? 0f
                    : StringToDouble(Convert.ToString(row[6]) ?? string.Empty),
                row.Count <= 7
                    ? 0f
                    : StringToDouble(Convert.ToString(row[7]) ?? string.Empty)
            );

        private double StringToDouble(string text)
           => string.IsNullOrEmpty(text) ? 0f : Convert.ToDouble(text);

        public SoundSetting GetModel(int index, IList<Object> row)
            => new SoundSetting(index, row);

    }
}