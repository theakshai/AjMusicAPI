using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AjMusicApi.Migrations
{
    /// <inheritdoc />
    public partial class _20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img_id",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img_id",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
