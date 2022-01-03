using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace google_sheet_api_service.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    gId = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    islandGid = table.Column<string>(type: "TEXT", nullable: false),
                    islandName = table.Column<string>(type: "TEXT", nullable: false),
                    maxLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    imageKey = table.Column<string>(type: "TEXT", nullable: false),
                    buildingNameKey = table.Column<string>(type: "TEXT", nullable: false),
                    buildingDescriptionKey = table.Column<string>(type: "TEXT", nullable: false),
                    alreadySettingBuildingLevelCount = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Building");
        }
    }
}
