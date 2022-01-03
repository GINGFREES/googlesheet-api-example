using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace google_sheet_api_service.Migrations.MvcCharacter
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    gId = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    islandGid = table.Column<int>(type: "INTEGER", nullable: false),
                    unlockedBuildingGid = table.Column<int>(type: "INTEGER", nullable: false),
                    unlockedBuildingName = table.Column<string>(type: "TEXT", nullable: false),
                    unlockedBuildingLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    nameKey = table.Column<string>(type: "TEXT", nullable: false),
                    descriptionKey = table.Column<string>(type: "TEXT", nullable: false),
                    imageKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");
        }
    }
}
