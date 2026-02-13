using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Weather.Core.Domain;
using Weather.Core.Options;
using Weather.Infrastructure.Entity.Mappings;

namespace Weather.Infrastructure.Entity.Contexts;

public class WeatherContext(IOptions<DatabaseOptions> options) : DbContext
{
    public DbSet<DeviceDataItem> DeviceData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(options.Value.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DeviceDataMap());
    }
}