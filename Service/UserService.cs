using Microsoft.EntityFrameworkCore;

public class UserService
{
    internal static async Task<User?> GetUserByName(UserDb context, string username)
    {
        return await context.Users
            .Include(u => u.UserShows)
            .ThenInclude(us => us.Show)
            .FirstOrDefaultAsync(u => u.Name == username);
    }

    internal static async Task<User?> GetUser(UserDb context, int id)
    {
        return await context.Users
            .Include(u => u.UserShows)
            .ThenInclude(us => us.Show)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    internal static async Task<List<User>>? GetUsers(UserDb context)
    {
        return await context.Users
            .Include(u => u.UserShows)
            .ThenInclude(us => us.Show)
            .ToListAsync();
    }

    internal static async Task<User> AddUser(UserDb context, RegisterRequest registerRequest)
    {
        var user = new User
        {
            Name = registerRequest.UserName,
            Email = registerRequest.Email,
            LoggedIn = true
        };

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return user;
    }

    internal static async Task<User> AddUserShow(UserDb context, int id, ShowRequest showRequest)
    {
        User? user = await GetUser(context, id);

        if (user == null)
        {
            return null;
        }

        if (user.UserShows.Any(us => us.Show.Id == showRequest.Id))
        {
            return user;
        }

        Show show = StoreEpisodesAndSeasons(context, showRequest);

        // Add to Shows table
        if (!await context.Shows.AnyAsync(s => s.Id == show.Id))
        {
            await context.Shows.AddAsync(show);
        }
        await context.SaveChangesAsync();

        // Add to UserShows table
        if (!await context.UserShows.AnyAsync(us => us.Show.Id == show.Id && us.User.Id == user.Id))
        {
            await context.UserShows.AddAsync(new UserShow { User = user, Show = show });
        }

        await context.UserShows.AddAsync(new UserShow { User = user, Show = show });
        await context.SaveChangesAsync();
        return user;
    }

    private static Show StoreEpisodesAndSeasons(UserDb context, ShowRequest showRequest)
    {
        // Store Episodes
        Show show = ShowsService.TransformRequest.ToShowObject(showRequest);
        List<TvEpisode?> tvEpisodes = showRequest.Episodes
            .Select(e => ShowsService.TransformRequest.ToTvEpisode(show.Id, e))
            .ToList();
        tvEpisodes.ForEach(async e =>
        {
            if (!await context.TvEpisodes.AnyAsync(episode => episode.WebId == e.Id))
            {
                await context.TvEpisodes.AddAsync(e);
            }
        });
        show.TvEpisodes = tvEpisodes;

        // Store Seasons
        List<Season> seasons = showRequest.Seasons
            .Select(s => ShowsService.TransformRequest.ToSeason(show.Id, s))
            .ToList();
        seasons.ForEach(async s =>
        {
            if (!await context.Seasons.AnyAsync(season => season.WebId == s.Id))
            {
                await context.Seasons.AddAsync(s);
            }
        });
        show.Seasons = seasons;

        // Store Next Episode
        show.NextEpisode = ShowsService.TransformRequest.ToTvEpisode(
            show.Id,
            showRequest.NextEpisode
        );
        return show;
    }

    internal static async Task<User?> RemoveUserShow(UserDb context, int id, int showId)
    {
        var user = await GetUser(context, id);
        if (user == null)
        {
            return null;
        }

        var userShow = user.UserShows.FirstOrDefault(us => us.Show.Id == showId);
        if (userShow == null)
        {
            return user;
        }

        context.UserShows.Remove(userShow);
        await context.SaveChangesAsync();

        return user;
    }

    internal static async Task<List<ShowRequest>> GetUserShows(UserDb context, int id)
    {
        var user = await context.Users
            .Include(u => u.UserShows)
            .ThenInclude(us => us.Show)
            .ThenInclude(s => s.TvEpisodes)
            .Include(u => u.UserShows)
            .ThenInclude(us => us.Show)
            .ThenInclude(s => s.Seasons)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            return null;
        }

        return user.UserShows
            .Select(
                us =>
                    ShowsService.TransformResponse.ToShowObject(
                        us.Show,
                        us.Show.TvEpisodes.ToList(),
                        us.Show.Seasons.ToList()
                    )
            )
            .ToList();
    }
}
