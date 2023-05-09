using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AjMusicApi.Migrations
{
    /// <inheritdoc />
    public partial class init30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayLists",
                table: "PlayLists");

            migrationBuilder.RenameTable(
                name: "PlayLists",
                newName: "PlayList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayList",
                table: "PlayList",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayList",
                table: "PlayList");

            migrationBuilder.RenameTable(
                name: "PlayList",
                newName: "PlayLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayLists",
                table: "PlayLists",
                column: "id");
        }
    }
}
