using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace R6Ranking.Migrations
{
    /// <inheritdoc />
    public partial class plswork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Maps",
                columns: new[] { "MapID", "MapName", "MapPhoto" },
                values: new object[,]
                {
                    { 1, "Bank", null },
                    { 2, "Border", null },
                    { 3, "Chalet", null },
                    { 4, "Clubhouse", null },
                    { 5, "Consulate", null },
                    { 6, "Kafe Dostoyevksy", null },
                    { 7, "Lair", null },
                    { 8, "Nighthaven Labs", null },
                    { 9, "Oregon", null },
                    { 10, "Skyscraper", null },
                    { 11, "Theme Park", null },
                    { 12, "Villa", null },
                    { 100, "DefaultMap", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "MapID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "MapID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "MapID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "MapID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "MapID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "MapID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "MapID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "MapID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "MapID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "MapID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "MapID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "MapID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Maps",
                keyColumn: "MapID",
                keyValue: 100);
        }
    }
}
