using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentAdministration.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryOfOrigin",
                table: "Player",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomeTown",
                table: "Player",
                type: "nvarchar(85)",
                maxLength: 85,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryOfOrigin",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "HomeTown",
                table: "Player");
        }
    }
}
