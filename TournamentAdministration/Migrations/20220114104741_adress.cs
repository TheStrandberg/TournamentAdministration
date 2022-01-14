using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentAdministration.Migrations
{
    public partial class adress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress_City",
                table: "Venue",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adress_Country",
                table: "Venue",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Adress_Postcode",
                table: "Venue",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adress_Street",
                table: "Venue",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress_City",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Adress_Country",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Adress_Postcode",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Adress_Street",
                table: "Venue");
        }
    }
}
