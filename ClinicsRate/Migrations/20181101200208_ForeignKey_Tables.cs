using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicsRate.Migrations
{
    public partial class ForeignKey_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_DictCities_DictCityId",
                table: "Clinics");

            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_DictProvinces_DictProvinceId",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_DictCityId",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_DictProvinceId",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "DictCityId",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "DictProvinceId",
                table: "Clinics");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Clinics",
                newName: "ProvinceId");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Clinics",
                newName: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_CityID",
                table: "Clinics",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_ProvinceId",
                table: "Clinics",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_DictCities_CityID",
                table: "Clinics",
                column: "CityID",
                principalTable: "DictCities",
                principalColumn: "DictCityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_DictProvinces_ProvinceId",
                table: "Clinics",
                column: "ProvinceId",
                principalTable: "DictProvinces",
                principalColumn: "DictProvinceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_DictCities_CityID",
                table: "Clinics");

            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_DictProvinces_ProvinceId",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_CityID",
                table: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Clinics_ProvinceId",
                table: "Clinics");

            migrationBuilder.RenameColumn(
                name: "ProvinceId",
                table: "Clinics",
                newName: "Province");

            migrationBuilder.RenameColumn(
                name: "CityID",
                table: "Clinics",
                newName: "City");

            migrationBuilder.AddColumn<int>(
                name: "DictCityId",
                table: "Clinics",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DictProvinceId",
                table: "Clinics",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_DictCityId",
                table: "Clinics",
                column: "DictCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_DictProvinceId",
                table: "Clinics",
                column: "DictProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_DictCities_DictCityId",
                table: "Clinics",
                column: "DictCityId",
                principalTable: "DictCities",
                principalColumn: "DictCityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_DictProvinces_DictProvinceId",
                table: "Clinics",
                column: "DictProvinceId",
                principalTable: "DictProvinces",
                principalColumn: "DictProvinceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
