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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TvEpisode>()
            .HasOne(e=>e.Show)
            .WithMany(s=>s.TvEpisodes)
            .HasForeignKey(e=>e.ShowId);
    }
}