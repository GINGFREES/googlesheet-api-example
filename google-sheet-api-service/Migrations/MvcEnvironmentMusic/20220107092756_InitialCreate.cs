using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace google_sheet_api_service.Migrations.MvcEnvironmentMusic
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnvironmentMusic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    islandGid = table.Column<int>(type: "INTEGER", nullable: false),
                    islandName = table.Column<string>(type: "TEXT", nullable: false),
                    music = table.Column<string>(type: "TEXT", nullable: false),
                    isLoop = table.Column<bool>(type: "INTEGER", nullable: false),
                    startDelay = table.Column<double>(type: "REAL", nullable: false),
                    isFadeLoop = table.Column<bool>(type: "INTEGER", nullable: false),
                    fadeLoopDelay = table.Column<double>(type: "REAL", nullable: false),
                    fadeOutDelay = table.Column<double>(type: "REAL", nullable: false),
                    fadeInOutDuration = table.Column<double>(type: "REAL", nullable: false),
                    fadeInOutEase = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentMusic", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnvironmentMusic");
        }
    }
}
