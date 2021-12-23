using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentAdministration.Data.Migrations
{
    public partial class TournamentHasAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Tournament",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_UserID",
                table: "Tournament",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_AspNetUsers_UserID",
                table: "Tournament",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_AspNetUsers_UserID",
                table: "Tournament");

            migrationBuilder.DropIndex(
                name: "IX_Tournament_UserID",
                table: "Tournament");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Tournament");
        }
    }
}
