using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace binge_buddy_api.Migrations
{
    /// <inheritdoc />
    public partial class TvEpisodeNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TvEpisodes_ShowId",
                table: "TvEpisodes");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodes_ShowId",
                table: "TvEpisodes",
                column: "ShowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TvEpisodes_ShowId",
                table: "TvEpisodes");

            migrationBuilder.CreateIndex(
                name: "IX_TvEpisodes_ShowId",
                table: "TvEpisodes",
                column: "ShowId",
                unique: true);
        }
    }
}
