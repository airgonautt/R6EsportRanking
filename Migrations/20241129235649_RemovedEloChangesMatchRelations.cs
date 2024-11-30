using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R6Ranking.Migrations
{
    /// <inheritdoc />
    public partial class RemovedEloChangesMatchRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_TeamEloChanges_Team1ID",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_TeamEloChanges_Team2ID",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamEloChanges_Matches_MatchID",
                table: "TeamEloChanges");

            migrationBuilder.DropIndex(
                name: "IX_TeamEloChanges_MatchID",
                table: "TeamEloChanges");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Team1ID",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Team2ID",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "MatchID",
                table: "TeamEloChanges");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team1ID",
                table: "Matches",
                column: "Team1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team2ID",
                table: "Matches",
                column: "Team2ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Matches_Team1ID",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Team2ID",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "MatchID",
                table: "TeamEloChanges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TeamEloChanges_MatchID",
                table: "TeamEloChanges",
                column: "MatchID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TeamEloChanges_Matches_MatchID",
                table: "TeamEloChanges",
                column: "MatchID",
                principalTable: "Matches",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
