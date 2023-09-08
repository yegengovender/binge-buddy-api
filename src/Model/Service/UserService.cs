using Microsoft.EntityFrameworkCore;

public class UserService
{
    private readonly UserDb _context;

    public UserService(UserDb context)
    {
        _context = context;
    }

    public async static Task<User>? Login(UserDb context, User user)
    {
        // Correct credentials
        var matchingUser = await context.Users
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
}
