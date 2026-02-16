using Weather.Core.Domain;

namespace Weather.WebApi.Dtos;

public class DeviceDataResponse
{
    public DateTime Date { get; set; }
    public double BaromRel { get; set; }
    public double TempOut { get; set; }
    public int HumidityOut { get; set; }
    public int WindDir { get; set; }
    public double WindSpeed { get; set; }
    public double WindGust { get; set; }
    public double EventRain { get; set; }
    public double DailyRain { get; set; }
    public int UvIndex { get; set; }
    public double FeelsLike { get; set; }
    public double DewPoint { get; set; }
    public double SolarRadiation { get; set; }

    public static DeviceDataResponse FromDomain(DeviceData data) => new()
    {
        Date = data.Date,
        BaromRel = data.BaromRel,
        TempOut = data.TempOut,
        HumidityOut = data.HumidityOut,
        WindDir = data.WindDir,
        WindSpeed = data.WindSpeed,
        WindGust = data.WindGust,
        EventRain = data.EventRain,
        DailyRain = data.DailyRain,
        UvIndex = data.Uv,
        SolarRadiation = data.SolarRadiation,
        FeelsLike = data.FeelsLike,
        DewPoint = data.DewPoint
    };
}
