using google_sheet_api_service.Models.Utils;
namespace google_sheet_api_service.Models
{
    public class Island : ModelBase<Island>
    {
        /// <summary>
        /// Model id, 固定值
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// 小島Gid
        /// </summary>
        /// <value></value>
        public int gId { get; set; }
        /// <summary>
        /// 小島名稱
        /// </summary>
        /// <value></value>
        public string islandName { get; set; }
        /// <summary>
        /// 圖檔key
        /// </summary>
        /// <value></value>
        public string imageKey { get; set; }
        /// <summary>
        /// 小島名稱 lokalise key
        /// </summary>
        /// <value></value>
        public string nameKey { get; set; }
        /// <summary>
        /// 小島描述 lokalise key
        /// </summary>
        /// <value></value>
        public string descriptionKey { get; set; }
        /// <summary>
        /// 小島結語 lokalise key
        /// </summary>
        /// <value></value>
        public string conclusionKey { get; set; }

        public Island()
        => (
            this.Id,
            this.gId,
            this.islandName,
            this.imageKey,
            this.nameKey,
            this.descriptionKey,
            this.conclusionKey
        )
        = (
            -1,
            -1,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty
        );

        public Island(int index, IList<Object> row)
        => (
            this.Id,
            this.gId,
            this.islandName,
            this.imageKey,
            this.nameKey,
            this.descriptionKey,
            this.conclusionKey
        )
        = (
            index,
            row.Count <= 0 ? -1 : Convert.ToInt32(row[0]),
            row.Count <= 1 ? string.Empty : Convert.ToString(row[1]) ?? string.Empty,
            row.Count <= 2 ? string.Empty : Convert.ToString(row[2]) ?? string.Empty,
            row.Count <= 3 ? string.Empty : Convert.ToString(row[3]) ?? string.Empty,
            row.Count <= 4 ? string.Empty : Convert.ToString(row[4]) ?? string.Empty,
            row.Count <= 5 ? string.Empty : Convert.ToString(row[5]) ?? string.Empty
        );

        public Island GetModel(int index, IList<Object> row)
            => new Island(index, row);
    }
}