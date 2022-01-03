using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace google_sheet_api_service.Migrations.MvcStoryDialogue
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StoryDialogue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    storyName = table.Column<string>(type: "TEXT", nullable: false),
                    stroyGid = table.Column<int>(type: "INTEGER", nullable: false),
                    characterName = table.Column<string>(type: "TEXT", nullable: false),
                    dialogueSortIndex = table.Column<int>(type: "INTEGER", nullable: false),
                    content = table.Column<string>(type: "TEXT", nullable: false),
                    contentKey = table.Column<string>(type: "TEXT", nullable: false),
                    optionDialogue01 = table.Column<string>(type: "TEXT", nullable: false),
                    optionDialogue02 = table.Column<string>(type: "TEXT", nullable: false),
                    optionDialogue01Key = table.Column<string>(type: "TEXT", nullable: false),
                    optionDialogue02Key = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoryDialogue", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoryDialogue");
        }
    }
}
