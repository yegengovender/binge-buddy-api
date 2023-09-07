using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace binge_buddy_api.Migrations
{
    /// <inheritdoc />
    public partial class UserShowsManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Users_UserId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_UserId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Shows");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Shows",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shows_UserId",
                table: "Shows",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Users_UserId",
                table: "Shows",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
