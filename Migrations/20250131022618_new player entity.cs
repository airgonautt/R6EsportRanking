using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R6Ranking.Migrations
{
    /// <inheritdoc />
    public partial class newplayerentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateJoined",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "DateLeft",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "Deaths",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Entry",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "KOST",
                table: "Players",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KPR",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Kills",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Plant",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UpcomingMatches",
                columns: table => new
                {
                    FutureMatchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VODURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Team1ID = table.Column<int>(type: "int", nullable: false),
                    Team2ID = table.Column<int>(type: "int", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpcomingMatches", x => x.FutureMatchID);
                    table.ForeignKey(
                        name: "FK_UpcomingMatches_Teams_Team1ID",
                        column: x => x.Team1ID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UpcomingMatches_Teams_Team2ID",
                        column: x => x.Team2ID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UpcomingMatches_Team1ID",
                table: "UpcomingMatches",
                column: "Team1ID");

            migrationBuilder.CreateIndex(
                name: "IX_UpcomingMatches_Team2ID",
                table: "UpcomingMatches",
                column: "Team2ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UpcomingMatches");

            migrationBuilder.DropColumn(
                name: "Deaths",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Entry",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "KOST",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "KPR",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Kills",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Plant",
                table: "Players");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateJoined",
                table: "Players",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLeft",
                table: "Players",
                type: "datetime2",
                nullable: true);
        }
    }
}
