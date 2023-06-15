using Microsoft.EntityFrameworkCore;

namespace CloudWeather.Temperature.DataAccess;

public class TemperatureDbContext : DbContext
{
    public DbSet<Temperature> Temperature { get; set; }

    public TemperatureDbContext() { }

    public TemperatureDbContext(DbContextOptions opts) : base(opts) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SnakeCaseIdentityTableNames(modelBuilder);
    }

    private static void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Temperature>(b => { b.ToTable("temperature"); });
    }
}
