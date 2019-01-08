using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicsRate.Migrations
{
    public partial class DodanieDoOpinionDateCreated_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Opinions",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Opinions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "(getdate())");
        }
    }
}
