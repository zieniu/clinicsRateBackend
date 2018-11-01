using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicsRate.Migrations
{
    public partial class changeNameToClinicName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clinics",
                newName: "ClinicName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClinicName",
                table: "Clinics",
                newName: "Name");
        }
    }
}
