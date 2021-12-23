using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentAdministration.Data.Migrations
{
    public partial class PlayerGameHandle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameHandle",
                table: "Player",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameHandle",
                table: "Player");
        }
    }
}
