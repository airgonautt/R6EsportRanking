using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R6Ranking.Migrations
{
    /// <inheritdoc />
    public partial class RenamedCountryType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Countries_CountryID",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_CountryID",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "OriginCountryCountryID",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_OriginCountryCountryID",
                table: "Players",
                column: "OriginCountryCountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Countries_OriginCountryCountryID",
                table: "Players",
                column: "OriginCountryCountryID",
                principalTable: "Countries",
                principalColumn: "CountryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Countries_OriginCountryCountryID",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_OriginCountryCountryID",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "OriginCountryCountryID",
                table: "Players");

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
    }
}
