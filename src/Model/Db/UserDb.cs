using Microsoft.EntityFrameworkCore;

class UserDb : DbContext
{
    public UserDb(DbContextOptions<UserDb> options)
        : base(options) { }

    // public DbSet<User> Users => Set<User>();
    // public DbSet<Show> Shows => Set<Show>();
    // public DbSet<TvEpisode> TvEpisodes => Set<TvEpisode>();
    // public DbSet<UserShow> UserShows => Set<UserShow>();
    // public DbSet<ShowsProgress> ShowsProgress => Set<ShowsProgress>();
}