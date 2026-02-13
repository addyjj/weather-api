using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Weather.Core.Domain;

namespace Weather.Infrastructure.Entity.Mappings;

internal class DeviceDataMap : IEntityTypeConfiguration<DeviceData>
{
    public void Configure(EntityTypeBuilder<DeviceData> builder)
    {
        builder.ToTable("DeviceData");
        builder.HasKey(x => x.DateUtc);

        builder.Property(x => x.DateUtc)
            .ValueGeneratedNever();

        builder.Property(x => x.TempIn).IsRequired();
        builder.Property(x => x.HumidityIn).IsRequired();
        builder.Property(x => x.BaromRel).IsRequired();
        builder.Property(x => x.BaromAbs).IsRequired();
        builder.Property(x => x.TempOut).IsRequired();
        builder.Property(x => x.BattOut).IsRequired();
        builder.Property(x => x.HumidityOut).IsRequired();
        builder.Property(x => x.WindDir).IsRequired();
        builder.Property(x => x.WindSpeed).IsRequired();
        builder.Property(x => x.WindGust).IsRequired();
        builder.Property(x => x.MaxDailyGust).IsRequired();
        builder.Property(x => x.HourlyRainRate).IsRequired();
        builder.Property(x => x.EventRain).IsRequired();
        builder.Property(x => x.DailyRain).IsRequired();
        builder.Property(x => x.WeeklyRain).IsRequired();
        builder.Property(x => x.MonthlyRain).IsRequired();
        builder.Property(x => x.TotalRain).IsRequired();
        builder.Property(x => x.SolarRadiation).IsRequired();
        builder.Property(x => x.Uv).IsRequired();
        builder.Property(x => x.BattCo2).IsRequired();
        builder.Property(x => x.FeelsLike).IsRequired();
        builder.Property(x => x.DewPoint).IsRequired();
        builder.Property(x => x.FeelsLikeIn).IsRequired();
        builder.Property(x => x.DewPointIn).IsRequired();
        builder.Property(x => x.Loc).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Date).IsRequired();
    }
}