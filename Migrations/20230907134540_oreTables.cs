using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace binge_buddy_api.Migrations
{
    /// <inheritdoc />
    public partial class oreTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Season_Show_ShowId",
                table: "Season");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_TvEpisode_NextEpisodeId",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_Show_Users_UserId",
                table: "Show");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowsProgress_UserShow_UserShowId",
                table: "ShowsProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_TvEpisode_Show_ShowId",
                table: "TvEpisode");

            migrationBuilder.DropForeignKey(
                name: "FK_UserShow_Users_UserId",
                table: "UserShow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserShow",
                table: "UserShow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TvEpisode",
                table: "TvEpisode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Show",
                table: "Show");

            migrationBuilder.RenameTable(
                name: "UserShow",
                newName: "UserShows");

            migrationBuilder.RenameTable(
                name: "TvEpisode",
                newName: "TvEpisodes");

            migrationBuilder.RenameTable(
                name: "Show",
                newName: "Shows");

            migrationBuilder.RenameIndex(
                name: "IX_UserShow_UserId",
                table: "UserShows",
                newName: "IX_UserShows_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TvEpisode_ShowId",
                table: "TvEpisodes",
                newName: "IX_TvEpisodes_ShowId");

            migrationBuilder.RenameIndex(
                name: "IX_Show_UserId",
                table: "Shows",
                newName: "IX_Shows_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Show_NextEpisodeId",
                table: "Shows",
                newName: "IX_Shows_NextEpisodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserShows",
                table: "UserShows",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TvEpisodes",
                table: "TvEpisodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shows",
                table: "Shows",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Shows_ShowId",
                table: "Season",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_TvEpisodes_NextEpisodeId",
                table: "Shows",
                column: "NextEpisodeId",
                principalTable: "TvEpisodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Users_UserId",
                table: "Shows",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowsProgress_UserShows_UserShowId",
                table: "ShowsProgress",
                column: "UserShowId",
                principalTable: "UserShows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TvEpisodes_Shows_ShowId",
                table: "TvEpisodes",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserShows_Users_UserId",
                table: "UserShows",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Season_Shows_ShowId",
                table: "Season");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_TvEpisodes_NextEpisodeId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Users_UserId",
                table: "Shows");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowsProgress_UserShows_UserShowId",
                table: "ShowsProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_TvEpisodes_Shows_ShowId",
                table: "TvEpisodes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserShows_Users_UserId",
                table: "UserShows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserShows",
                table: "UserShows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TvEpisodes",
                table: "TvEpisodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shows",
                table: "Shows");

            migrationBuilder.RenameTable(
                name: "UserShows",
                newName: "UserShow");

            migrationBuilder.RenameTable(
                name: "TvEpisodes",
                newName: "TvEpisode");

            migrationBuilder.RenameTable(
                name: "Shows",
                newName: "Show");

            migrationBuilder.RenameIndex(
                name: "IX_UserShows_UserId",
                table: "UserShow",
                newName: "IX_UserShow_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TvEpisodes_ShowId",
                table: "TvEpisode",
                newName: "IX_TvEpisode_ShowId");

            migrationBuilder.RenameIndex(
                name: "IX_Shows_UserId",
                table: "Show",
                newName: "IX_Show_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Shows_NextEpisodeId",
                table: "Show",
                newName: "IX_Show_NextEpisodeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserShow",
                table: "UserShow",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TvEpisode",
                table: "TvEpisode",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Show",
                table: "Show",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Show_ShowId",
                table: "Season",
                column: "ShowId",
                principalTable: "Show",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Show_TvEpisode_NextEpisodeId",
                table: "Show",
                column: "NextEpisodeId",
                principalTable: "TvEpisode",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Show_Users_UserId",
                table: "Show",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowsProgress_UserShow_UserShowId",
                table: "ShowsProgress",
                column: "UserShowId",
                principalTable: "UserShow",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TvEpisode_Show_ShowId",
                table: "TvEpisode",
                column: "ShowId",
                principalTable: "Show",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserShow_Users_UserId",
                table: "UserShow",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
