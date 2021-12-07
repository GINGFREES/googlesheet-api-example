using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace google_sheet_api_service.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Test1 = table.Column<string>(type: "TEXT", nullable: false),
                    Test2 = table.Column<string>(type: "TEXT", nullable: false),
                    Test3 = table.Column<string>(type: "TEXT", nullable: false),
                    Test4 = table.Column<string>(type: "TEXT", nullable: false),
                    Test5 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestFile", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestFile");
        }
    }
}
