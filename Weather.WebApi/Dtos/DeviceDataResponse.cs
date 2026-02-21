using Weather.Core.Domain;
using Weather.Infrastructure.Services.External.Dtos;

namespace Weather.WebApi.Dtos;

public class DeviceDataResponse
{
    public DateTime Date { get; }
    public double BaromRel { get; }
    public double TempOut { get; }
    public int HumidityOut { get; }
    public int WindDir { get; }
    public double WindSpeed { get; }
    public double WindGust { get; }
    public double EventRain { get; }
    public double DailyRain { get; }
    public int UvIndex { get; }
    public double FeelsLike { get; }
    public double DewPoint { get; }
    public double SolarRadiation { get; }

    public DeviceDataResponse() { }

    public DeviceDataResponse(DeviceData data)
    {
        Date = data.Date;
        BaromRel = data.BaromRel;
        TempOut = data.TempOut;
        HumidityOut = data.HumidityOut;
        WindDir = data.WindDir;
        WindSpeed = data.WindSpeed;
        WindGust = data.WindGust;
        EventRain = data.EventRain;
        DailyRain = data.DailyRain;
        UvIndex = data.Uv;
        SolarRadiation = data.SolarRadiation;
        FeelsLike = data.FeelsLike;
        DewPoint = data.DewPoint;
    }

    public DeviceDataResponse(AmbientWeatherDeviceData data) : this(data.ToDomain()) { }
}
