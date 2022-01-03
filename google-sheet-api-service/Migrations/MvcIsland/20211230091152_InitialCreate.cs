using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace google_sheet_api_service.Migrations.MvcIsland
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Island",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    gId = table.Column<int>(type: "INTEGER", nullable: false),
                    islandName = table.Column<string>(type: "TEXT", nullable: false),
                    imageKey = table.Column<string>(type: "TEXT", nullable: false),
                    nameKey = table.Column<string>(type: "TEXT", nullable: false),
                    descriptionKey = table.Column<string>(type: "TEXT", nullable: false),
                    conclusionKey = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Island", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Island");
        }
    }
}
