using System.ComponentModel;
using Weather.Core.Domain;
using Weather.Infrastructure.Services.External.Dtos;

namespace Weather.WebApi.Dtos;

public class DeviceDataResponse
{
    [Description("The timestamp of the weather reading")]
    public DateTime Date { get; }
    
    [Description("Relative barometric pressure in inHg")]
    public double BaromRel { get; }
    
    [Description("Outdoor temperature in fahrenheit")]
    public double TempOut { get; }
    
    [Description("Outdoor humidity percentage")]
    public int HumidityOut { get; }
    
    [Description("Wind direction in degrees (0-360)")]
    public int WindDir { get; }
    
    [Description("Wind speed in mph")]
    public double WindSpeed { get; }
    
    [Description("Wind gust speed in mph")]
    public double WindGust { get; }
    
    [Description("Rain amount since last report in inches")]
    public double EventRain { get; }
    
    [Description("Total rainfall for the day in inches")]
    public double DailyRain { get; }
    
    [Description("UV index value")]
    public int UvIndex { get; }
    
    [Description("Perceived temperature in fahrenheit")]
    public double FeelsLike { get; }
    
    [Description("Dew point temperature in fahrenheit")]
    public double DewPoint { get; }
    
    [Description("Solar radiation in W/m²")]
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
