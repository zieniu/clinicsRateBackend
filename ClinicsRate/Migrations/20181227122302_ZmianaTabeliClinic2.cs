using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicsRate.Migrations
{
    public partial class ZmianaTabeliClinic2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Accepted",
                table: "Clinics",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int),
                oldDefaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Accepted",
                table: "Clinics",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldDefaultValueSql: "((0))");
        }
    }
}
