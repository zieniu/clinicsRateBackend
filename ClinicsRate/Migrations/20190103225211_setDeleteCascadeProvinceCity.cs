using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicsRate.Migrations
{
    public partial class setDeleteCascadeProvinceCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_DictCities_CityId",
                table: "Clinics");

            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_DictProvinces_ProvinceId",
                table: "Clinics");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_DictCities_CityId",
                table: "Clinics",
                column: "CityId",
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
                name: "FK_Clinics_DictCities_CityId",
                table: "Clinics");

            migrationBuilder.DropForeignKey(
                name: "FK_Clinics_DictProvinces_ProvinceId",
                table: "Clinics");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_DictCities_CityId",
                table: "Clinics",
                column: "CityId",
                principalTable: "DictCities",
                principalColumn: "DictCityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clinics_DictProvinces_ProvinceId",
                table: "Clinics",
                column: "ProvinceId",
                principalTable: "DictProvinces",
                principalColumn: "DictProvinceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
