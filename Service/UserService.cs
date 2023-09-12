using Microsoft.EntityFrameworkCore;

public class UserService
{
    internal static async Task<UserRequest?> AddUser(
        UserDb context,
        RegisterRequest registerRequest
    )
    {
        var user = new User
        {
            Name = registerRequest.UserName,
            Email = registerRequest.Email,
            LoggedIn = true
        };

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return await GetUser(context, user.Id);
    }

    internal static async Task<UserRequest?> GetUserByName(UserDb context, string username)
    {
        var user = await ServiceHelpers
            .GetDbUsers(context)
            .FirstOrDefaultAsync(u => u.Name == username);
        return ShowsService.TransformResponse.ToUser(user, user.UserShows.ToList());
    }

    internal static async Task<UserRequest?> GetUser(UserDb context, int userId)
    {
        var user = await ServiceHelpers
            .GetDbUsers(context)
            .FirstOrDefaultAsync(u => u.Id == userId);
        return ShowsService.TransformResponse.ToUser(user, user.UserShows.ToList());
    }

    internal static async Task<List<UserRequest>>? GetUsers(UserDb context)
    {
        return await ServiceHelpers
            .GetDbUsers(context)
            .Select(u => ShowsService.TransformResponse.ToUser(u, u.UserShows.ToList()))
            .ToListAsync();
    }

    internal static async Task<UserRequest?> AddUserShow(
        UserDb context,
        int userId,
        ShowRequest showRequest
    )
    {
        var user = await ServiceHelpers
            .GetDbUsers(context)
            .FirstOrDefaultAsync(u => u.Id == userId);

        // User not found
        if (user == null)
        {
            return null;
        }

        // Show already exists
        if (user.UserShows.Any(us => us.Show.Id == showRequest.Id))
        {
            return ShowsService.TransformResponse.ToUser(user, user.UserShows.ToList());
        }

        // *********
        // New Entry
        Show show = ServiceHelpers.StoreEpisodesAndSeasons(context, showRequest);

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

        await context.SaveChangesAsync();
        return await GetUser(context, user.Id);
    }

    internal static async Task<UserRequest?> RemoveUserShow(UserDb context, int userId, int showId)
    {
        var user = await ServiceHelpers
            .GetDbUsers(context)
            .FirstOrDefaultAsync(u => u.Id == userId);

        // var user = await GetUser(context, id);
        if (user == null)
        {
            return null;
        }

        var userShow = user.UserShows.FirstOrDefault(us => us.Show.WebId == showId);
        if (userShow == null)
        {
            return ShowsService.TransformResponse.ToUser(user, user.UserShows.ToList());
        }

        context.UserShows.Remove(userShow);
        await context.SaveChangesAsync();

        return await GetUser(context, user.Id);
    }

    internal static async Task<List<ShowRequest>> GetUserShows(UserDb context, int id)
    {
        var user = await ServiceHelpers.GetDbUsers(context).FirstOrDefaultAsync(u => u.Id == id);

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
