using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AjMusicApi.Migrations
{
    /// <inheritdoc />
    public partial class Init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    followers = table.Column<int>(type: "int", nullable: true),
                    img_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    track_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    artist_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    added_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    img_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    likes = table.Column<int>(type: "int", nullable: true),
                    duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    preview_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.track_id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    following = table.Column<int>(type: "int", nullable: true),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
