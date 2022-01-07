using google_sheet_api_service.Models.Utils;
namespace google_sheet_api_service.Models
{
    public class EnvironmentMusic : ModelBase<EnvironmentMusic>
    {
        public int Id { get; set; }
        public int islandGid { get; set; }
        public string islandName { get; set; }
        public string music { get; set; }
        public bool isLoop { get; set; }
        public double startDelay { get; set; }
        public bool isFadeLoop { get; set; }
        public double fadeLoopDelay { get; set; }
        public double fadeOutDelay { get; set; }
        public double fadeInOutDuration { get; set; }
        public string fadeInOutEase { get; set; }

        public EnvironmentMusic()
        => (
            this.Id,
            this.islandGid,
            this.islandName,
            this.music,
            this.isLoop,
            this.startDelay,
            this.isFadeLoop,
            this.fadeLoopDelay,
            this.fadeOutDelay,
            this.fadeInOutDuration,
            this.fadeInOutEase
        ) = (
            -1,
            -1,
            string.Empty,
            string.Empty,
            false,
            0f,
            false,
            0f,
            0f,
            0f,
            string.Empty
        );

        public EnvironmentMusic(int index, IList<Object> row)
        => (
            this.Id,
        this.islandGid,
        this.islandName,
        this.music,
        this.isLoop,
        this.startDelay,
        this.isFadeLoop,
        this.fadeLoopDelay,
        this.fadeOutDelay,
        this.fadeInOutDuration,
        this.fadeInOutEase
        ) = (
            index,
            row.Count <= 0 ? -1 : Convert.ToInt32(row[0]),
            row.Count <= 1 ? string.Empty : Convert.ToString(row[1]) ?? string.Empty,
            row.Count <= 2 ? string.Empty : Convert.ToString(row[2]) ?? string.Empty,
            row.Count <= 3 ? false : Convert.ToBoolean(row[3]),
            row.Count <= 4 ? 0f : StringToDouble(Convert.ToString(row[4]) ?? string.Empty),
            row.Count <= 5 ? false : Convert.ToBoolean(row[5]),
            row.Count <= 6 ? 0f : StringToDouble(Convert.ToString(row[6]) ?? string.Empty),
            row.Count <= 7 ? 0f : StringToDouble(Convert.ToString(row[7]) ?? string.Empty),
            row.Count <= 8 ? 0f : StringToDouble(Convert.ToString(row[8]) ?? string.Empty),
            row.Count <= 9 ? string.Empty : Convert.ToString(row[9]) ?? string.Empty
        );

        private double StringToDouble(string text)
           => string.IsNullOrEmpty(text) ? 0f : Convert.ToDouble(text);

        public EnvironmentMusic GetModel(int index, IList<Object> row)
            => new EnvironmentMusic(index, row);
    }
}