using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentAdministration.Data.Migrations
{
    public partial class TournamentPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_Player_PlayerID",
                table: "Tournament");

            migrationBuilder.DropIndex(
                name: "IX_Tournament_PlayerID",
                table: "Tournament");

            migrationBuilder.DropColumn(
                name: "PlayerID",
                table: "Tournament");

            migrationBuilder.CreateTable(
                name: "PlayerTournament",
                columns: table => new
                {
                    PlayersID = table.Column<int>(type: "int", nullable: false),
                    TournamentsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTournament", x => new { x.PlayersID, x.TournamentsID });
                    table.ForeignKey(
                        name: "FK_PlayerTournament_Player_PlayersID",
                        column: x => x.PlayersID,
                        principalTable: "Player",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTournament_Tournament_TournamentsID",
                        column: x => x.TournamentsID,
                        principalTable: "Tournament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTournament_TournamentsID",
                table: "PlayerTournament",
                column: "TournamentsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerTournament");

            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                table: "Tournament",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_PlayerID",
                table: "Tournament",
                column: "PlayerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_Player_PlayerID",
                table: "Tournament",
                column: "PlayerID",
                principalTable: "Player",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
