using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentAdministration.Migrations
{
    public partial class adressfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress_Street",
                table: "Venue",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Adress_Postcode",
                table: "Venue",
                newName: "Postcode");

            migrationBuilder.RenameColumn(
                name: "Adress_Country",
                table: "Venue",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Adress_City",
                table: "Venue",
                newName: "City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Venue",
                newName: "Adress_Street");

            migrationBuilder.RenameColumn(
                name: "Postcode",
                table: "Venue",
                newName: "Adress_Postcode");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Venue",
                newName: "Adress_Country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Venue",
                newName: "Adress_City");
        }
    }
}
