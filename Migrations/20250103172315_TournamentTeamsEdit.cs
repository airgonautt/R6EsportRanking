using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R6Ranking.Migrations
{
    /// <inheritdoc />
    public partial class TournamentTeamsEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrimaryColor",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EloRating",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TournamentTeams",
                columns: table => new
                {
                    TournamentTeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentID = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentTeams", x => x.TournamentTeamID);
                    table.ForeignKey(
                        name: "FK_TournamentTeams_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentTeams_Tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TournamentTeams_TeamID",
                table: "TournamentTeams",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentTeams_TournamentID",
                table: "TournamentTeams",
                column: "TournamentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TournamentTeams");

            migrationBuilder.DropColumn(
                name: "PrimaryColor",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "EloRating",
                table: "Players");
        }
    }
}
