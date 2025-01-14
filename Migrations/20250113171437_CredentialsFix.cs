using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R6Ranking.Migrations
{
    /// <inheritdoc />
    public partial class CredentialsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userAccountsPolicies",
                table: "userAccountsPolicies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userAccounts",
                table: "userAccounts");

            migrationBuilder.RenameTable(
                name: "userAccountsPolicies",
                newName: "UserAccountsPolicies");

            migrationBuilder.RenameTable(
                name: "userAccounts",
                newName: "UserAccounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccountsPolicies",
                table: "UserAccountsPolicies",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts",
                column: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccountsPolicies",
                table: "UserAccountsPolicies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccounts",
                table: "UserAccounts");

            migrationBuilder.RenameTable(
                name: "UserAccountsPolicies",
                newName: "userAccountsPolicies");

            migrationBuilder.RenameTable(
                name: "UserAccounts",
                newName: "userAccounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userAccountsPolicies",
                table: "userAccountsPolicies",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userAccounts",
                table: "userAccounts",
                column: "ID");
        }
    }
}
