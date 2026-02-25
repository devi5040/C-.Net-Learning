using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;

namespace UrlShortener.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<ShortUrl> ShortUrls => Set<ShortUrl>();
    public DbSet<ClickEvent> ClickEvents => Set<ClickEvent>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Unique index on ShortCode for faster lookups
        modelBuilder.Entity<ShortUrl>().HasIndex(s => s.ShortCode).IsUnique();

        // Index on short url id for fast analytics queries
        modelBuilder.Entity<ClickEvent>().HasIndex(c => c.ShortUrlId);

        // Index on clickedAt for date range queries
        modelBuilder.Entity<ClickEvent>().HasIndex(c => c.ClickedAt);

        modelBuilder.Entity<ShortUrl>().HasMany(s => s.ClickEvents).WithOne(c => c.ShortUrl).HasForeignKey(c => c.ShortUrlId).OnDelete(DeleteBehavior.Cascade);
    }
}