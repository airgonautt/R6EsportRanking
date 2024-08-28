using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R6Ranking.Migrations
{
    /// <inheritdoc />
    public partial class changedOpBans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperatorBans_Matches_MatchID",
                table: "OperatorBans");

            migrationBuilder.AlterColumn<string>(
                name: "OperatorName",
                table: "OperatorBans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "OperatorLogo",
                table: "OperatorBans",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MatchID",
                table: "OperatorBans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorBans_Matches_MatchID",
                table: "OperatorBans",
                column: "MatchID",
                principalTable: "Matches",
                principalColumn: "MatchID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperatorBans_Matches_MatchID",
                table: "OperatorBans");

            migrationBuilder.AlterColumn<string>(
                name: "OperatorName",
                table: "OperatorBans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OperatorLogo",
                table: "OperatorBans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MatchID",
                table: "OperatorBans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorBans_Matches_MatchID",
                table: "OperatorBans",
                column: "MatchID",
                principalTable: "Matches",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
