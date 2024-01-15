using Microsoft.EntityFrameworkCore;
using Weather.Core.Domain;
using Weather.Infrastructure.Entity.Mappings;

namespace Weather.Infrastructure.Entity.Contexts;

public class WeatherContext(AppConfig config) : DbContext
{
    public required DbSet<DeviceDataItem> DeviceData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(config.SqlConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DeviceDataMap());
    }
}