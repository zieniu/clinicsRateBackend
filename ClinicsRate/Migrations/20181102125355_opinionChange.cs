using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicsRate.Migrations
{
    public partial class opinionChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_User_UserId",
                table: "Opinions");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Opinions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_User_UserId",
                table: "Opinions",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_User_UserId",
                table: "Opinions");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Opinions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_User_UserId",
                table: "Opinions",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
