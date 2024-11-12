using Microsoft.EntityFrameworkCore;
using ScoutApp.Core;

namespace ScoutApp.Infrastructure;

public class ScoutAppDbContext : DbContext
{
    public DbSet<Scout> Scouts { get; set; }
    public DbSet<Activity> Activities { get; set; }

    public ScoutAppDbContext(DbContextOptions<ScoutAppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define many-to-many relationship between Scouts and Activities
        // Without this configuration, it will be a one-to-many relationship
        modelBuilder.Entity<Activity>()
            .HasMany(a => a.Participants) // One Activity has many Participants
            .WithMany(); // No need to specify the navigation property on the other side
    }
}
