using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicsRate.Migrations
{
    public partial class UzupelnienieTabeliUser_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccessLevel",
                table: "User",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccessLevel",
                table: "User",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "((0))");
        }
    }
}
