using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace google_sheet_api_service.Migrations.MvcBuildingLevelSize
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingLevelSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    buildingName = table.Column<string>(type: "TEXT", nullable: false),
                    buildingLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    islandGid = table.Column<int>(type: "INTEGER", nullable: false),
                    buildingGid = table.Column<int>(type: "INTEGER", nullable: false),
                    checkAnim = table.Column<string>(type: "TEXT", nullable: false),
                    levelUpAnim = table.Column<string>(type: "TEXT", nullable: false),
                    buildingSize = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingLevelSize", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingLevelSize");
        }
    }
}
