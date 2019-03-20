using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment3_S19.Data.Migrations
{
    public partial class AddedCompaniesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<string>(nullable: false),
                    Symbol = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(maxLength: 10, nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    IexId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
