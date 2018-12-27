using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicsRate.Migrations
{
    public partial class UzupelnienieTabeliUser_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "User",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateCreated",
                table: "User",
                nullable: true,
                defaultValue: "getdate()",
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "(getdate())");
        }
    }
}
