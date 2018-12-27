using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicsRate.Migrations
{
    public partial class ZmianaTabeliClinic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicsTMP");

            migrationBuilder.AddColumn<int>(
                name: "Accepted",
                table: "Clinics",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "Clinics");

            migrationBuilder.CreateTable(
                name: "ClinicsTMP",
                columns: table => new
                {
                    ClinicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityId = table.Column<int>(nullable: false),
                    ClinicName = table.Column<string>(nullable: true),
                    DictCityId = table.Column<int>(nullable: true),
                    DictProvinceId = table.Column<int>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: false),
                    Street = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicsTMP", x => x.ClinicId);
                    table.ForeignKey(
                        name: "FK_ClinicsTMP_DictCities_DictCityId",
                        column: x => x.DictCityId,
                        principalTable: "DictCities",
                        principalColumn: "DictCityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClinicsTMP_DictProvinces_DictProvinceId",
                        column: x => x.DictProvinceId,
                        principalTable: "DictProvinces",
                        principalColumn: "DictProvinceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicsTMP_DictCityId",
                table: "ClinicsTMP",
                column: "DictCityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicsTMP_DictProvinceId",
                table: "ClinicsTMP",
                column: "DictProvinceId");
        }
    }
}
