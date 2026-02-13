namespace Weather.Core.Domain;

public class DeviceData
{
    /// <summary>
    ///     Datetime, int (milliseconds from 01-01-1970, rounded down to nearest minute on server)
    /// </summary>
    public long DateUtc { get; set; }

    /// <summary>
    ///     Indoor Temperature, ºF
    /// </summary>
    public double TempIn { get; set; }

    /// <summary>
    ///     Indoor Humidity, 0-100%
    /// </summary>
    public int HumidityIn { get; set; }

    /// <summary>
    ///     Relative Pressure, inHg
    /// </summary>
    public double BaromRel { get; set; }

    /// <summary>
    ///     Absolute Pressure, inHg
    /// </summary>
    public double BaromAbs { get; set; }

    /// <summary>
    ///     Outdoor Temperature, ºF
    /// </summary>
    public double TempOut { get; set; }

    /// <summary>
    ///     Outdoor Battery - OK/Low indication, Int, 1=OK, 0=Low (Meteobridge Users 1=Low, 0=OK)
    /// </summary>
    public bool BattOut { get; set; }

    /// <summary>
    ///     Outdoor Humidity, 0-100%
    /// </summary>
    public int HumidityOut { get; set; }

    /// <summary>
    ///     instantaneous wind direction, 0-360º
    /// </summary>
    public int WindDir { get; set; }

    /// <summary>
    ///     instantaneous wind speed, mph
    /// </summary>
    public double WindSpeed { get; set; }

    /// <summary>
    ///     max wind speed in the last 10 minutes, mph
    /// </summary>
    public double WindGust { get; set; }

    /// <summary>
    ///     Maximum wind speed in last day, mph
    /// </summary>
    public double MaxDailyGust { get; set; }

    /// <summary>
    ///     Hourly Rain Rate, inches/hr
    /// </summary>
    public double HourlyRainRate { get; set; }

    /// <summary>
    ///     Event Rain, inches
    /// </summary>
    public double EventRain { get; set; }

    /// <summary>
    ///     Daily Rain, inches
    /// </summary>
    public double DailyRain { get; set; }

    /// <summary>
    ///     Weekly Rain, inches
    /// </summary>
    public double WeeklyRain { get; set; }

    /// <summary>
    ///     Monthly Rain, inches
    /// </summary>
    public double MonthlyRain { get; set; }

    /// <summary>
    ///     Total Rain, inches (since last factory reset)
    /// </summary>
    public double TotalRain { get; set; }

    /// <summary>
    ///     Solar Radiation, W/m^2
    /// </summary>
    public double SolarRadiation { get; set; }

    /// <summary>
    ///     Ultra-Violet Radiation Index
    /// </summary>
    public int Uv { get; set; }

    /// <summary>
    ///     CO2 battery - 1=OK, 0=Low
    /// </summary>
    public bool BattCo2 { get; set; }

    /// <summary>
    ///     if < 50ºF => Wind Chill, if > 68ºF => Heat Index (calculated on server)
    /// </summary>
    public double FeelsLike { get; set; }

    /// <summary>
    ///     Indoor Feels Like
    /// </summary>
    public double DewPoint { get; set; }

    /// <summary>
    ///     Indoor Feels Like
    /// </summary>
    public double FeelsLikeIn { get; set; }

    /// <summary>
    ///     Dew Point, ºF (calculated on server)
    /// </summary>
    public double DewPointIn { get; set; }

    public string Loc { get; set; } = "";

    public DateTime Date { get; set; }
}