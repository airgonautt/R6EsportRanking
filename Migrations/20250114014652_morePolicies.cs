using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R6Ranking.Migrations
{
    /// <inheritdoc />
    public partial class morePolicies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 1,
                column: "UserPolicy",
                value: "VIEW");

            migrationBuilder.UpdateData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 2,
                column: "UserPolicy",
                value: "ADD");

            migrationBuilder.UpdateData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 3,
                column: "UserPolicy",
                value: "EDIT");

            migrationBuilder.UpdateData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 4,
                column: "UserPolicy",
                value: "DELETE");

            migrationBuilder.UpdateData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 5,
                column: "UserPolicy",
                value: "VIEW");

            migrationBuilder.UpdateData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 6,
                column: "UserPolicy",
                value: "ADD");

            migrationBuilder.UpdateData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 7,
                column: "UserPolicy",
                value: "EDIT");

            migrationBuilder.UpdateData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 8,
                column: "UserPolicy",
                value: "DELETE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 1,
                column: "UserPolicy",
                value: "VIEW_PRODUCT");

            migrationBuilder.UpdateData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 2,
                column: "UserPolicy",
                value: "ADD_PRODUCT");

            migrationBuilder.UpdateData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 3,
                column: "UserPolicy",
                value: "EDIT_PRODUCT");

            migrationBuilder.UpdateData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 4,
                column: "UserPolicy",
                value: "DELETE_PRODUCT");

            migrationBuilder.UpdateData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 5,
                column: "UserPolicy",
                value: "VIEW_PRODUCT");

            migrationBuilder.UpdateData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 6,
                column: "UserPolicy",
                value: "VIEW_PRODUCT");

            migrationBuilder.UpdateData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 7,
                column: "UserPolicy",
                value: "VIEW_PRODUCT");

            migrationBuilder.UpdateData(
                table: "UserAccountsPolicies",
                keyColumn: "ID",
                keyValue: 8,
                column: "UserPolicy",
                value: "VIEW_PRODUCT");
        }
    }
}
