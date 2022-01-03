﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace google_sheet_api_service.Migrations.MvcStory
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Story",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    gId = table.Column<int>(type: "INTEGER", nullable: false),
                    stroyName = table.Column<string>(type: "TEXT", nullable: false),
                    characterGid = table.Column<int>(type: "INTEGER", nullable: false),
                    characterName = table.Column<string>(type: "TEXT", nullable: false),
                    buildingName = table.Column<string>(type: "TEXT", nullable: false),
                    buildingLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    buildingGid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Story", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Story");
        }
    }
}
