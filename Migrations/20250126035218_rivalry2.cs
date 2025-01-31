using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R6Ranking.Migrations
{
    /// <inheritdoc />
    public partial class rivalry2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamRivalryID",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamRivalries",
                columns: table => new
                {
                    TeamRivalryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    RivalTeamID = table.Column<int>(type: "int", nullable: false),
                    MatchesPlayed = table.Column<int>(type: "int", nullable: false),
                    MatchesWon = table.Column<int>(type: "int", nullable: false),
                    MatchesLost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRivalries", x => x.TeamRivalryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TeamRivalryID",
                table: "Matches",
                column: "TeamRivalryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_TeamRivalries_TeamRivalryID",
                table: "Matches",
                column: "TeamRivalryID",
                principalTable: "TeamRivalries",
                principalColumn: "TeamRivalryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_TeamRivalries_TeamRivalryID",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "TeamRivalries");

            migrationBuilder.DropIndex(
                name: "IX_Matches_TeamRivalryID",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "TeamRivalryID",
                table: "Matches");
        }
    }
}
