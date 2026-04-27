using System.ComponentModel;

namespace Weather.Core.Domain;

public class DeviceData
{
    /// <summary>
    ///     Datetime, int (milliseconds from 01-01-1970, rounded down to nearest minute on server)
    /// </summary>
    [Description("Timestamp in milliseconds since 1970-01-01 UTC (rounded down to the nearest minute on the server).")]
    public long DateUtc { get; set; }

    /// <summary>
    ///     Indoor Temperature, ºF
    /// </summary>
    [Description("Indoor temperature, °F.")]
    public double TempIn { get; set; }

    /// <summary>
    ///     Indoor Humidity, 0-100%
    /// </summary>
    [Description("Indoor humidity, 0-100%.")]
    public int HumidityIn { get; set; }

    /// <summary>
    ///     Relative Pressure, inHg
    /// </summary>
    [Description("Relative pressure, inHg.")]
    public double BaromRel { get; set; }

    /// <summary>
    ///     Absolute Pressure, inHg
    /// </summary>
    [Description("Absolute pressure, inHg.")]
    public double BaromAbs { get; set; }

    /// <summary>
    ///     Outdoor Temperature, ºF
    /// </summary>
    [Description("Outdoor temperature, °F.")]
    public double TempOut { get; set; }

    /// <summary>
    ///     Outdoor Battery - OK/Low indication, Int, 1=OK, 0=Low (Meteobridge Users 1=Low, 0=OK)
    /// </summary>
    [Description("Outdoor battery status (true = OK, false = Low). Meteobridge users: true = Low, false = OK.")]
    public bool BattOut { get; set; }

    /// <summary>
    ///     Outdoor Humidity, 0-100%
    /// </summary>
    [Description("Outdoor humidity, 0-100%.")]
    public int HumidityOut { get; set; }

    /// <summary>
    ///     instantaneous wind direction, 0-360º
    /// </summary>
    [Description("Instantaneous wind direction, 0-360°.")]
    public int WindDir { get; set; }

    /// <summary>
    ///     instantaneous wind speed, mph
    /// </summary>
    [Description("Instantaneous wind speed, mph.")]
    public double WindSpeed { get; set; }

    /// <summary>
    ///     max wind speed in the last 10 minutes, mph
    /// </summary>
    [Description("Max wind speed in the last 10 minutes, mph.")]
    public double WindGust { get; set; }

    /// <summary>
    ///     Maximum wind speed in last day, mph
    /// </summary>
    [Description("Maximum wind speed in the last day, mph.")]
    public double MaxDailyGust { get; set; }

    /// <summary>
    ///     Hourly Rain Rate, inches/hr
    /// </summary>
    [Description("Hourly rain rate, inches per hour.")]
    public double HourlyRainRate { get; set; }

    /// <summary>
    ///     Event Rain, inches
    /// </summary>
    [Description("Event rain total, inches.")]
    public double EventRain { get; set; }

    /// <summary>
    ///     Daily Rain, inches
    /// </summary>
    [Description("Daily rain total, inches.")]
    public double DailyRain { get; set; }

    /// <summary>
    ///     Weekly Rain, inches
    /// </summary>
    [Description("Weekly rain total, inches.")]
    public double WeeklyRain { get; set; }

    /// <summary>
    ///     Monthly Rain, inches
    /// </summary>
    [Description("Monthly rain total, inches.")]
    public double MonthlyRain { get; set; }

    /// <summary>
    ///     Total Rain, inches (since last factory reset)
    /// </summary>
    [Description("Total rain since last factory reset, inches.")]
    public double TotalRain { get; set; }

    /// <summary>
    ///     Solar Radiation, W/m^2
    /// </summary>
    [Description("Solar radiation, W/m².")]
    public double SolarRadiation { get; set; }

    /// <summary>
    ///     Ultra-Violet Radiation Index
    /// </summary>
    [Description("UV index.")]
    public int Uv { get; set; }

    /// <summary>
    ///     CO2 battery - 1=OK, 0=Low
    /// </summary>
    [Description("CO2 battery status (true = OK, false = Low).")]
    public bool BattCo2 { get; set; }

    /// <summary>
    ///     if < 50ºF => Wind Chill, if > 68ºF => Heat Index (calculated on server)
    /// </summary>
    [Description("Outdoor Feels-like temperature, °F (wind chill below 50°F; heat index above 68°F; calculated on server).")]
    public double FeelsLike { get; set; }

    /// <summary>
    ///     Outdoor Dew Point, fahrenheit
    /// </summary>
    [Description("Outdoor dew point, fahrenheit")]
    public double DewPoint { get; set; }

    /// <summary>
    ///     Indoor feels-like temperature, fahrenheit.
    /// </summary>
    [Description("Indoor feels-like temperature, fahrenheit.")]
    public double FeelsLikeIn { get; set; }

    /// <summary>
    ///     Indoor Dew Point, fahrenheit
    /// </summary>
    [Description("Indoor Dew Point, fahrenheit")]
    public double DewPointIn { get; set; }

    [Description("Location identifier for the reading.")]
    public string Loc { get; set; } = "";

    [Description("Timestamp of the reading, UTC.")]
    public DateTime Date { get; set; }
}