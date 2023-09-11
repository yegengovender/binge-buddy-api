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
        var user = await context.Users.FindAsync(userId);
        return user;
    }
}
