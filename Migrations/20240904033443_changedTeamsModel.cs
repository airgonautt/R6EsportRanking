using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R6Ranking.Migrations
{
    /// <inheritdoc />
    public partial class changedTeamsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Teams_TeamID",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_TeamID",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Tournaments");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Teams",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "TeamID",
                table: "Tournaments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TeamID",
                table: "Tournaments",
                column: "TeamID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Teams_TeamID",
                table: "Tournaments",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID");
        }
    }
}
