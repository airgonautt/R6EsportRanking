using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace R6Ranking.Migrations
{
    /// <inheritdoc />
    public partial class AccountAndPolicies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "ID", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "userPassword", "public user" },
                    { 505, "adminPassword", "admin1" }
                });

            migrationBuilder.InsertData(
                table: "UserAccountsPolicies",
                columns: new[] { "ID", "IsEnabled", "UserAccountID", "UserPolicy" },
                values: new object[,]
                {
                    { 1, false, 1, "VIEW_PRODUCT" },
                    { 2, false, 1, "ADD_PRODUCT" },
                    { 3, false, 1, "EDIT_PRODUCT" },
                    { 4, false, 1, "DELETE_PRODUCT" },
                    { 5, true, 505, "VIEW_PRODUCT" },
                    { 6, true, 505, "VIEW_PRODUCT" },
                    { 7, true, 505, "VIEW_PRODUCT" },
                    { 8, true, 505, "VIEW_PRODUCT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "ID",
                keyValue: 505);

            migrationBuilder.DeleteData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 8);

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
    }
}
