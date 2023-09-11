using Microsoft.EntityFrameworkCore;

public class UserShowsService
{
    internal static async Task<UserRequest> WatchedEpisode(
        UserDb context,
        int userId,
        int episodeId,
        bool isWatched
    )
    {
        var user = await ServiceHelpers
            .GetDbUsers(context)
            .FirstOrDefaultAsync(u => u.Id == userId);

        var episode = user.UserShows
            .SelectMany(s => s.Show.TvEpisodes)
            .First(e => e.WebId == episodeId);

        UserShowActivity userShowActivity = new UserShowActivity
        {
            Episode = episode,
            UserShow = user.UserShows.First(
                us => us.Show.TvEpisodes.Any(e => e.WebId == episodeId)
            ),
            Updated = DateTime.Now
        };

        if (!isWatched)
        {
            context.UserShowActivity.Remove(
                context.UserShowActivity.First(
                    usa => usa.Episode.WebId == episodeId && usa.UserShow.User.Id == userId
                )
            );
        }
        else
        {
            context.UserShowActivity.Add(userShowActivity);
        }

        context.SaveChanges();
        return ShowsService.TransformResponse.ToUser(user, user.UserShows.ToList());
    }
}
