using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Weather.Core.Domain;

namespace Weather.Infrastructure.Entity.Mappings
{
    internal class DeviceDataMap : IEntityTypeConfiguration<DeviceDataItem>
    {
        public void Configure(EntityTypeBuilder<DeviceDataItem> builder)
        {
            builder.ToTable("DeviceData");
            builder.HasKey(x => x.DateUtc);
            builder.Property(x => x.TempIn);
            builder.Property(x => x.HumidityIn);
            builder.Property(x => x.BaromRel);
            builder.Property(x => x.BaromAbs);
            builder.Property(x => x.TempOut);
            builder.Property(x => x.BattOut);
            builder.Property(x => x.HumidityOut);
            builder.Property(x => x.WindDir);
            builder.Property(x => x.WindSpeed);
            builder.Property(x => x.WindGust);
            builder.Property(x => x.MaxDailyGust);
            builder.Property(x => x.HourlyRainRate);
            builder.Property(x => x.EventRain);
            builder.Property(x => x.DailyRain);
            builder.Property(x => x.WeeklyRain);
            builder.Property(x => x.MonthlyRain);
            builder.Property(x => x.TotalRain);
            builder.Property(x => x.SolarRadiation);
            builder.Property(x => x.Uv);
            builder.Property(x => x.BattCo2);
            builder.Property(x => x.FeelsLike);
            builder.Property(x => x.DewPoint);
            builder.Property(x => x.FeelsLikeIn);
            builder.Property(x => x.DewPointIn);
            builder.Property(x => x.Loc);
            builder.Property(x => x.Date);
        }
    }
}
