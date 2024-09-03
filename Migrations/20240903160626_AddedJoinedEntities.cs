using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R6Ranking.Migrations
{
    /// <inheritdoc />
    public partial class AddedJoinedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperatorBans_Matches_MatchID",
                table: "OperatorBans");

            migrationBuilder.DropIndex(
                name: "IX_OperatorBans_MatchID",
                table: "OperatorBans");

            migrationBuilder.DropColumn(
                name: "RivalTeamName",
                table: "TeamEloChanges");

            migrationBuilder.DropColumn(
                name: "MatchID",
                table: "OperatorBans");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tournaments",
                newName: "TournamentName");

            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Tournaments",
                newName: "TournamentLogo");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Tournaments",
                newName: "TournamentLocation");

            migrationBuilder.AlterColumn<int>(
                name: "MatchID",
                table: "TeamEloChanges",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MatchOperatorBans",
                columns: table => new
                {
                    MatchID = table.Column<int>(type: "int", nullable: false),
                    OperatorBanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchOperatorBans", x => new { x.MatchID, x.OperatorBanID });
                    table.ForeignKey(
                        name: "FK_MatchOperatorBans_Matches_MatchID",
                        column: x => x.MatchID,
                        principalTable: "Matches",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchOperatorBans_OperatorBans_OperatorBanID",
                        column: x => x.OperatorBanID,
                        principalTable: "OperatorBans",
                        principalColumn: "OperatorBanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trophies",
                columns: table => new
                {
                    TrophyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrophyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrophyPhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TournamentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trophies", x => x.TrophyID);
                    table.ForeignKey(
                        name: "FK_Trophies_Tournaments_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchOperatorBans_OperatorBanID",
                table: "MatchOperatorBans",
                column: "OperatorBanID");

            migrationBuilder.CreateIndex(
                name: "IX_Trophies_TournamentID",
                table: "Trophies",
                column: "TournamentID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchOperatorBans");

            migrationBuilder.DropTable(
                name: "Trophies");

            migrationBuilder.RenameColumn(
                name: "TournamentName",
                table: "Tournaments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TournamentLogo",
                table: "Tournaments",
                newName: "Logo");

            migrationBuilder.RenameColumn(
                name: "TournamentLocation",
                table: "Tournaments",
                newName: "Location");

            migrationBuilder.AlterColumn<int>(
                name: "MatchID",
                table: "TeamEloChanges",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "RivalTeamName",
                table: "TeamEloChanges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatchID",
                table: "OperatorBans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperatorBans_MatchID",
                table: "OperatorBans",
                column: "MatchID");

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorBans_Matches_MatchID",
                table: "OperatorBans",
                column: "MatchID",
                principalTable: "Matches",
                principalColumn: "MatchID");
        }
    }
}
