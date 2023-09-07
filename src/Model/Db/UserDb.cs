using Microsoft.EntityFrameworkCore;

class UserDb : DbContext
{
    public UserDb(DbContextOptions<UserDb> options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Show> Shows => Set<Show>();
    public DbSet<UserShow> UserShows => Set<UserShow>();
    public DbSet<TvEpisode> TvEpisodes => Set<TvEpisode>();
    public DbSet<Season> Seasons => Set<Season>();
    public DbSet<UserShowActivity> UserShowActivity => Set<UserShowActivity>();
}