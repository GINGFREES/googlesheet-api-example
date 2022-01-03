using google_sheet_api_service.Models.Utils;
namespace google_sheet_api_service.Models
{
    public class StoryDialogue : ModelBase<StoryDialogue>
    {
        public int Id { get; set; }
        public string storyName { get; set; }
        public int stroyGid { get; set; }
        public string characterName { get; set; }
        public int dialogueSortIndex { get; set; }
        public string content { get; set; }
        public string contentKey { get; set; }
        public string optionDialogue01 { get; set; }
        public string optionDialogue02 { get; set; }
        public string optionDialogue01Key { get; set; }
        public string optionDialogue02Key { get; set; }

        public StoryDialogue()
        => (
            this.Id,
            this.storyName,
            this.stroyGid,
            this.characterName,
            this.dialogueSortIndex,
            this.content,
            this.contentKey,
            this.optionDialogue01,
            this.optionDialogue02,
            this.optionDialogue01Key,
            this.optionDialogue02Key
        )
        = (
            -1,
            string.Empty,
            -1,
            string.Empty,
            -1,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty
        );

        public StoryDialogue(int index, IList<Object> row)
        =>
            (
            this.Id,
            this.storyName,
            this.stroyGid,
            this.characterName,
            this.dialogueSortIndex,
            this.content,
            this.contentKey,
            this.optionDialogue01,
            this.optionDialogue02,
            this.optionDialogue01Key,
            this.optionDialogue02Key
        )
        = (
            index,
            row.Count <= 0 ? string.Empty : Convert.ToString(row[0]) ?? string.Empty,
            row.Count <= 1 ? -1 : Convert.ToInt32(row[1]),
            row.Count <= 2 ? string.Empty : Convert.ToString(row[2]) ?? string.Empty,
            row.Count <= 3 ? -1 : Convert.ToInt32(row[3]),
            row.Count <= 4 ? string.Empty : Convert.ToString(row[4]) ?? string.Empty,
            row.Count <= 5 ? string.Empty : Convert.ToString(row[5]) ?? string.Empty,
            row.Count <= 6 ? string.Empty : Convert.ToString(row[6]) ?? string.Empty,
            row.Count <= 7 ? string.Empty : Convert.ToString(row[7]) ?? string.Empty,
            row.Count <= 8 ? string.Empty : Convert.ToString(row[8]) ?? string.Empty,
            row.Count <= 9 ? string.Empty : Convert.ToString(row[9]) ?? string.Empty
        );


        public StoryDialogue GetModel(int index, IList<Object> row)
            => new StoryDialogue(index, row);
    }
}