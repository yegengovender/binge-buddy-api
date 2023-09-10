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

        Show show = ShowsService.TransformRequest.ToShowObject(showRequest);
        await context.Shows.AddAsync(show);
        await context.SaveChangesAsync();

        await context.UserShows.AddAsync(new UserShow { User = user, Show = show });
        await context.SaveChangesAsync();
        return user;
    }

    internal static async Task<User> RemoveUserShow(UserDb context, int id, int showId)
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

    internal static async Task<User> GetUserShows(UserDb context, int id)
    {
        var user = await context.Users
            .Include(u => u.UserShows)
            .ThenInclude(us => us.Show)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            return null;
        }

        return user;
    }
}
