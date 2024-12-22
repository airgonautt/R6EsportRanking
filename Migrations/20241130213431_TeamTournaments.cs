using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R6Ranking.Migrations {
    /// <inheritdoc />
    public partial class TeamTournaments : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {


            migrationBuilder.CreateTable(
                name: "TeamTournament",
                columns: table => new {
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    TournamentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_TeamTournament", x => new { x.TeamID, x.TournamentID });
                    table.ForeignKey(
                        name: "FK_TeamTournament_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamTournament_Tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamTournament_TournamentID",
                table: "TeamTournament",
                column: "TournamentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {

            migrationBuilder.CreateTable(
                name: "TeamTournaments",
                columns: table => new {
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    TournamentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_TeamTournaments", x => new { x.TeamID, x.TournamentID });
                    table.ForeignKey(
                        name: "FK_TeamTournaments_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamTournaments_Tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamTournaments_TournamentID",
                table: "TeamTournaments",
                column: "TournamentID");
        }
    }
}
