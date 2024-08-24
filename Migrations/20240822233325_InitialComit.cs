using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace R6Ranking.Migrations
{
    /// <inheritdoc />
    public partial class InitialComit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Map",
                columns: table => new
                {
                    MapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MapPhoto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map", x => x.MapID);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrentElo = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_Regions_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Regions",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamID = table.Column<int>(type: "int", nullable: true),
                    DateJoined = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateLeft = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinnerTeamID = table.Column<int>(type: "int", nullable: true),
                    RegionID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TeamID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentID);
                    table.ForeignKey(
                        name: "FK_Tournaments_Regions_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Regions",
                        principalColumn: "RegionID");
                    table.ForeignKey(
                        name: "FK_Tournaments_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                    table.ForeignKey(
                        name: "FK_Tournaments_Teams_WinnerTeamID",
                        column: x => x.WinnerTeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Team1ID = table.Column<int>(type: "int", nullable: false),
                    Team1Score = table.Column<int>(type: "int", nullable: false),
                    Team2ID = table.Column<int>(type: "int", nullable: false),
                    Team2Score = table.Column<int>(type: "int", nullable: false),
                    MapID = table.Column<int>(type: "int", nullable: false),
                    TournamentID = table.Column<int>(type: "int", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
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
                name: "OperatorBans",
                columns: table => new
                {
                    OperatorBanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorBans", x => x.OperatorBanID);
                    table.ForeignKey(
                        name: "FK_OperatorBans_Matches_MatchID",
                        column: x => x.MatchID,
                        principalTable: "Matches",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamEloChanges",
                columns: table => new
                {
                    TeamEloChangeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    RivalTeamID = table.Column<int>(type: "int", nullable: true),
                    RivalTeamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatchID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TournamentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentElo = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    EloChange = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false)
                },
                constraints: table =>
                {
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

            migrationBuilder.InsertData(
                table: "Map",
                columns: new[] { "MapID", "MapName", "MapPhoto" },
                values: new object[,]
                {
                    { 1, "Bank", null },
                    { 2, "Border", null },
                    { 3, "Chalet", null },
                    { 4, "Clubhouse", null },
                    { 5, "Consulate", null },
                    { 6, "Kafe Dostoyevksy", null },
                    { 7, "Lair", null },
                    { 8, "Nighthaven Labs", null },
                    { 9, "Oregon", null },
                    { 10, "Skyscraper", null },
                    { 11, "Theme Park", null },
                    { 12, "Villa", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MapID",
                table: "Matches",
                column: "MapID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team1ID",
                table: "Matches",
                column: "Team1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team2ID",
                table: "Matches",
                column: "Team2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TournamentID",
                table: "Matches",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorBans_MatchID",
                table: "OperatorBans",
                column: "MatchID");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamID",
                table: "Players",
                column: "TeamID");

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
                name: "IX_Teams_RegionID",
                table: "Teams",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_RegionID",
                table: "Tournaments",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TeamID",
                table: "Tournaments",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_WinnerTeamID",
                table: "Tournaments",
                column: "WinnerTeamID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperatorBans");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "TeamEloChanges");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Map");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
