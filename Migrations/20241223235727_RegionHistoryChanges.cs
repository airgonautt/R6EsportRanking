using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace R6Ranking.Migrations
{
    /// <inheritdoc />
    public partial class RegionHistoryChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Regions");

            migrationBuilder.AddColumn<int>(
                name: "RegionalElo",
                table: "Regions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SocialUrl",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VODURL",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionalElo",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "SocialUrl",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "VODURL",
                table: "Matches");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Regions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Regions",
                type: "datetime2",
                nullable: true);
        }
    }
}
