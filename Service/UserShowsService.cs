using Microsoft.EntityFrameworkCore;

public class UserShowsService
{
    internal static async Task<User> WatchedEpisode(
        UserDb context,
        int userId,
        int episodeId,
        bool isWatched
    )
    {
        if (!isWatched)
        {
            var userShow = await context.UserShowActivity.FirstOrDefaultAsync(
                us => us.User.Id == userId && us.Episode.Id == episodeId
            );
            if (userShow != null)
            {
                context.UserShowActivity.Remove(userShow);
                await context.SaveChangesAsync();
            }
            return context.Users.Find(userId);
        }

        var episode = await context.TvEpisodes.FirstOrDefaultAsync(e => e.WebId == episodeId);
        episode.WatchedDate = DateTime.Now.ToString();

        var userShowActivity = new UserShowActivity
        {
            User = await context.Users.FindAsync(userId),
            Episode = episode,
            Updated = DateTime.Now
        };

        await context.UserShowActivity.AddAsync(userShowActivity);
        await context.SaveChangesAsync();
        return userShowActivity.User;
    }
}
