using Microsoft.EntityFrameworkCore;

public class UserService
{
    public async static Task<User>? Login(UserDb context, User user)
    {
        // Correct credentials
        var matchingUser = await context.Users
        .Include(u => u.UserShows)
        .ThenInclude(us => us.Show)
        .FirstOrDefaultAsync(u => u.Email == user.Email && user.Name == u.Name);
        if (matchingUser != null)
        {
            matchingUser.LoggedIn = true;
            await context.SaveChangesAsync();
            return matchingUser;
        }

        // Inorrect credentials
        if (await context.Users.AnyAsync(u => u.Email == user.Email || user.Name == u.Name))
        {
            return null;
        }

        // New credentials
        user.LoggedIn = true;
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return await context.Users.FirstOrDefaultAsync(u => u.Email == user.Email && user.Name == u.Name);
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
    
    internal async static Task<User> AddUserShow(UserDb context, int id, Show show)
    {
        User? user = await GetUser(context, id);

        if (user == null)
        {
            return null;
        }

        if (user.UserShows.Any(us => us.Show.Id == show.Id))
        {
            return user;
        }

        await context.Shows.AddAsync(show);
        await context.SaveChangesAsync();

        await context.UserShows.AddAsync(new UserShow { User = user, Show = show });
        await context.SaveChangesAsync();
        return user;
    }

    internal async static Task<User> RemoveUserShow(UserDb context, int id, int showId)
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
