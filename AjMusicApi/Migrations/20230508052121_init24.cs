using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AjMusicApi.Migrations
{
    /// <inheritdoc />
    public partial class init24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "added_on",
                table: "Tracks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "added_on",
                table: "Tracks",
                type: "datetime2",
                nullable: true);
        }
    }
}
