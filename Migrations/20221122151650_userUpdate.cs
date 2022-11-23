using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaBestiaNet.Migrations
{
    /// <inheritdoc />
    public partial class userUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Users",
                newName: "Gendre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gendre",
                table: "Users",
                newName: "Genre");
        }
    }
}
