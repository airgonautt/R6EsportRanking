using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace R6Ranking.Migrations {
    /// <inheritdoc />
    public partial class SynchronizeTeamOperatorBans : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {

            migrationBuilder.CreateTable(
                name: "OperatorBans",
                columns: table => new {
                    OperatorBanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatorLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatorSide = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_OperatorBans", x => x.OperatorBanID);
                });

            migrationBuilder.CreateTable(
                name: "RegionEloChanges",
                columns: table => new {
                    RegionEloHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentElo = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    EloChange = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_RegionEloChanges", x => x.RegionEloHistoryID);
                    table.ForeignKey(
                        name: "FK_RegionEloChanges_Regions_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Regions",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new {
                    MatchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Team1ID = table.Column<int>(type: "int", nullable: false),
                    Team1Score = table.Column<int>(type: "int", nullable: false),
                    Team2ID = table.Column<int>(type: "int", nullable: false),
                    Team2Score = table.Column<int>(type: "int", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MapID = table.Column<int>(type: "int", nullable: false),
                    TournamentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Matches", x => x.MatchID);
                    table.ForeignKey(
                        name: "FK_Matches_Map_MapID",
                        column: x => x.MapID,
                        principalTable: "Map",
                        principalColumn: "MapID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_Team1ID",
                        column: x => x.Team1ID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_Team2ID",
                        column: x => x.Team2ID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamEloChanges",
                columns: table => new {
                    TeamEloChangeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    RivalTeamID = table.Column<int>(type: "int", nullable: true),
                    CurrentElo = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    EloChange = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_TeamEloChanges", x => x.TeamEloChangeID);
                    table.ForeignKey(
                        name: "FK_TeamEloChanges_Matches_MatchID",
                        column: x => x.MatchID,
                        principalTable: "Matches",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamEloChanges_Teams_RivalTeamID",
                        column: x => x.RivalTeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamEloChanges_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamOperatorBans",
                columns: table => new {
                    TeamOperatorBanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    OperatorBanID = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_TeamOperatorBans", x => x.TeamOperatorBanID);
                    table.ForeignKey(
                        name: "FK_TeamOperatorBans_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamOperatorBans_OperatorBans_OperatorBanID",
                        column: x => x.OperatorBanID,
                        principalTable: "OperatorBans",
                        principalColumn: "OperatorBanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamOperatorBans_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Map",
                columns: new[] { "MapID", "MapName", "MapPhoto" },
                values: new object[,]
                {
                    { 100, "DefaultMap", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MapID",
                table: "Matches",
                column: "MapID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team1ID",
                table: "Matches",
                column: "Team1ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team2ID",
                table: "Matches",
                column: "Team2ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TournamentID",
                table: "Matches",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_RegionEloChanges_RegionID",
                table: "RegionEloChanges",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamEloChanges_MatchID",
                table: "TeamEloChanges",
                column: "MatchID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamEloChanges_RivalTeamID",
                table: "TeamEloChanges",
                column: "RivalTeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamEloChanges_TeamID",
                table: "TeamEloChanges",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamOperatorBans_MatchId",
                table: "TeamOperatorBans",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamOperatorBans_OperatorBanID",
                table: "TeamOperatorBans",
                column: "OperatorBanID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamOperatorBans_TeamID",
                table: "TeamOperatorBans",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_TeamEloChanges_Team1ID",
                table: "Matches",
                column: "Team1ID",
                principalTable: "TeamEloChanges",
                principalColumn: "TeamEloChangeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_TeamEloChanges_Team2ID",
                table: "Matches",
                column: "Team2ID",
                principalTable: "TeamEloChanges",
                principalColumn: "TeamEloChangeID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Map_MapID",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_TeamEloChanges_Team1ID",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_TeamEloChanges_Team2ID",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "RegionEloChanges");

            migrationBuilder.DropTable(
                name: "TeamOperatorBans");

            migrationBuilder.DropTable(
                name: "TeamTournaments");

            migrationBuilder.DropTable(
                name: "Trophies");

            migrationBuilder.DropTable(
                name: "OperatorBans");

            migrationBuilder.DropTable(
                name: "Map");

            migrationBuilder.DropTable(
                name: "TeamEloChanges");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
