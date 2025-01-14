using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R6Ranking.Migrations
{
    /// <inheritdoc />
    public partial class Credentials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Map_MapID",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Map",
                table: "Map");

            migrationBuilder.RenameTable(
                name: "Map",
                newName: "Maps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maps",
                table: "Maps",
                column: "MapID");

            migrationBuilder.CreateTable(
                name: "userAccounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAccounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "userAccountsPolicies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserAccountID = table.Column<int>(type: "int", nullable: false),
                    UserPolicy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAccountsPolicies", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Maps_MapID",
                table: "Matches",
                column: "MapID",
                principalTable: "Maps",
                principalColumn: "MapID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Maps_MapID",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "userAccounts");

            migrationBuilder.DropTable(
                name: "userAccountsPolicies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maps",
                table: "Maps");

            migrationBuilder.RenameTable(
                name: "Maps",
                newName: "Map");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Map",
                table: "Map",
                column: "MapID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Map_MapID",
                table: "Matches",
                column: "MapID",
                principalTable: "Map",
                principalColumn: "MapID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
