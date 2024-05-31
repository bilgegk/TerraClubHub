using Microsoft.EntityFrameworkCore;

public class ClubHubContext : DbContext
{
    public ClubHubContext(DbContextOptions<ClubHubContext> options)
        : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }
    public DbSet<Club> Clubs { get; set; }
    public DbSet<ClubActivity> ClubActivities { get; set; }

    // Override the OnModelCreating method to configure the model further
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the decimal properties in ClubActivity
        modelBuilder.Entity<ClubActivity>(entity =>
        {
            entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)"); // Setting the precision to 18 and scale to 2
            entity.Property(e => e.CostPerPerson).HasColumnType("decimal(18, 2)");
        });
    }
}
