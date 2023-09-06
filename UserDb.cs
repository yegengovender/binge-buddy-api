using Microsoft.EntityFrameworkCore;

class UserDb : DbContext
{
    public UserDb(DbContextOptions<UserDb> options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TvEpisode>()
            .HasOne(episode => episode.Show)             // TvEpisode has one Show
            .WithMany(show => show.Episodes)             // Show has many Episodes
            .HasForeignKey(episode => episode.ShowId);   // Explicitly specify the foreign key

        // modelBuilder.Entity<TvEpisode>()
        //     .HasOne(episode => episode.Show)
        //     .WithOne(show => show.NextEpisode)
        //     .HasForeignKey(episode => episode.ShowId);
    }

}