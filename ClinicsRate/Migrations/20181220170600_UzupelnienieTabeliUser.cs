using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicsRate.Migrations
{
    public partial class UzupelnienieTabeliUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateCreated",
                table: "User",
                nullable: true,
                defaultValue: "getdate()");

            migrationBuilder.AddColumn<int>(
                name: "Deleted",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ClinicsTMP",
                columns: table => new
                {
                    ClinicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    ClinicName = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: false),
                    DictProvinceId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    DictCityId = table.Column<int>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicsTMP");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "User");
        }
    }
}
