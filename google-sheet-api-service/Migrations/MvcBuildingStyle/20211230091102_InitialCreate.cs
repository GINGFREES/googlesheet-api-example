using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace google_sheet_api_service.Migrations.MvcBuildingStyle
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingStyle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    gId = table.Column<int>(type: "INTEGER", nullable: false),
                    buildingStyleName = table.Column<string>(type: "TEXT", nullable: false),
                    islandGid = table.Column<int>(type: "INTEGER", nullable: false),
                    buildingGid = table.Column<int>(type: "INTEGER", nullable: false),
                    buildingName = table.Column<string>(type: "TEXT", nullable: false),
                    minLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    imageKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingStyle", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingStyle");
        }
    }
}
