using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace google_sheet_api_service.Migrations.MvcSoundSetting
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SoundSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    islandGid = table.Column<int>(type: "INTEGER", nullable: false),
                    islandName = table.Column<string>(type: "TEXT", nullable: false),
                    bgmVolume = table.Column<double>(type: "REAL", nullable: false),
                    windVolume = table.Column<double>(type: "REAL", nullable: false),
                    waveVolume = table.Column<double>(type: "REAL", nullable: false),
                    birdVolume = table.Column<double>(type: "REAL", nullable: false),
                    lakeVolume = table.Column<double>(type: "REAL", nullable: false),
                    bellVolume = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundSetting", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SoundSetting");
        }
    }
}
