using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace binge_buddy_api.Migrations
{
    /// <inheritdoc />
    public partial class UserShowActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserShowActivity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    EpisodeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserShowActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserShowActivity_TvEpisodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "TvEpisodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserShowActivity_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserShowActivity_EpisodeId",
                table: "UserShowActivity",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserShowActivity_UserId",
                table: "UserShowActivity",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserShowActivity");
        }
    }
}
