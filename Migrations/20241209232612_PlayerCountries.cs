using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R6Ranking.Migrations {
    /// <inheritdoc />
    public partial class PlayerCountries : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isBo3",
                table: "Matches",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryFlag = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_CountryID",
                table: "Players",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Countries_CountryID",
                table: "Players",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Countries_CountryID",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Players_CountryID",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "isBo3",
                table: "Matches");
        }
    }
}
