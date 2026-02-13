using System.Text.Json.Serialization;
using Weather.Core.Domain;

namespace Weather.Infrastructure.Services.External.Dtos;

public class AmbientWeatherDeviceDataDto
{
    [JsonPropertyName("dateutc")]
    public long DateUtc { get; set; }

    [JsonPropertyName("tempinf")]
    public double TempIn { get; set; }

    [JsonPropertyName("humidityin")]
    public int HumidityIn { get; set; }

    [JsonPropertyName("baromrelin")]
    public double BaromRel { get; set; }

    [JsonPropertyName("baromabsin")]
    public double BaromAbs { get; set; }

    [JsonPropertyName("tempf")]
    public double TempOut { get; set; }

    [JsonPropertyName("battout")]
    [JsonConverter(typeof(BoolConverter))]
    public bool BattOut { get; set; }

    [JsonPropertyName("humidity")]
    public int HumidityOut { get; set; }

    [JsonPropertyName("winddir")]
    public int WindDir { get; set; }

    [JsonPropertyName("windspeedmph")]
    public double WindSpeed { get; set; }

    [JsonPropertyName("windgustmph")]
    public double WindGust { get; set; }

    [JsonPropertyName("maxdailygust")]
    public double MaxDailyGust { get; set; }

    [JsonPropertyName("hourlyrainin")]
    public double HourlyRainRate { get; set; }

    [JsonPropertyName("eventrainin")]
    public double EventRain { get; set; }

    [JsonPropertyName("dailyrainin")]
    public double DailyRain { get; set; }

    [JsonPropertyName("weeklyrainin")]
    public double WeeklyRain { get; set; }

    [JsonPropertyName("monthlyrainin")]
    public double MonthlyRain { get; set; }

    [JsonPropertyName("totalrainin")]
    public double TotalRain { get; set; }

    [JsonPropertyName("solarradiation")]
    public double SolarRadiation { get; set; }

    [JsonPropertyName("uv")]
    public int Uv { get; set; }

    [JsonPropertyName("batt_co2")]
    [JsonConverter(typeof(BoolConverter))]
    public bool BattCo2 { get; set; }

    [JsonPropertyName("feelsLike")]
    public double FeelsLike { get; set; }

    [JsonPropertyName("dewPoint")]
    public double DewPoint { get; set; }

    [JsonPropertyName("feelsLikein")]
    public double FeelsLikeIn { get; set; }

    [JsonPropertyName("dewPointin")]
    public double DewPointIn { get; set; }

    [JsonPropertyName("loc")]
    public string Loc { get; set; } = "";

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    public DeviceData ToDomain() => new()
    {
        DateUtc = DateUtc,
        TempIn = TempIn,
        HumidityIn = HumidityIn,
        BaromRel = BaromRel,
        BaromAbs = BaromAbs,
        TempOut = TempOut,
        BattOut = BattOut,
        HumidityOut = HumidityOut,
        WindDir = WindDir,
        WindSpeed = WindSpeed,
        WindGust = WindGust,
        MaxDailyGust = MaxDailyGust,
        HourlyRainRate = HourlyRainRate,
        EventRain = EventRain,
        DailyRain = DailyRain,
        WeeklyRain = WeeklyRain,
        MonthlyRain = MonthlyRain,
        TotalRain = TotalRain,
        SolarRadiation = SolarRadiation,
        Uv = Uv,
        BattCo2 = BattCo2,
        FeelsLike = FeelsLike,
        DewPoint = DewPoint,
        FeelsLikeIn = FeelsLikeIn,
        DewPointIn = DewPointIn,
        Loc = Loc,
        Date = Date
    };
}
