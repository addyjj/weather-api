using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Weather.Core.Domain;
using Weather.Core.Options;
using Weather.Infrastructure.Data.Configurations;

namespace Weather.Infrastructure.Data.Contexts;

public class WeatherContext(IOptions<DatabaseOptions> options) : DbContext
{
    public DbSet<DeviceData> DeviceData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(options.Value.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DeviceDataConfiguration());
    }
}
