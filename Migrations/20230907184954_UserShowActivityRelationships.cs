using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace binge_buddy_api.Migrations
{
    /// <inheritdoc />
    public partial class UserShowActivityRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserShowActivity_TvEpisodes_EpisodeId",
                table: "UserShowActivity");

            migrationBuilder.RenameColumn(
                name: "EpisodeId",
                table: "UserShowActivity",
                newName: "TvEpisodeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserShowActivity_EpisodeId",
                table: "UserShowActivity",
                newName: "IX_UserShowActivity_TvEpisodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserShowActivity_TvEpisodes_TvEpisodeId",
                table: "UserShowActivity",
                column: "TvEpisodeId",
                principalTable: "TvEpisodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserShowActivity_TvEpisodes_TvEpisodeId",
                table: "UserShowActivity");

            migrationBuilder.RenameColumn(
                name: "TvEpisodeId",
                table: "UserShowActivity",
                newName: "EpisodeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserShowActivity_TvEpisodeId",
                table: "UserShowActivity",
                newName: "IX_UserShowActivity_EpisodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserShowActivity_TvEpisodes_EpisodeId",
                table: "UserShowActivity",
                column: "EpisodeId",
                principalTable: "TvEpisodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
