using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R6Ranking.Migrations {
    /// <inheritdoc />
    public partial class OpBansWorkaround : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<int>(
                name: "Team1Ban1",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Team1Ban2",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Team2Ban1",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Team2Ban2",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "Team1Ban1",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Team1Ban2",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Team2Ban1",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Team2Ban2",
                table: "Matches");
        }
    }
}
