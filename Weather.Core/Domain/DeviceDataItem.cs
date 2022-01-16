using System.Text.Json.Serialization;

namespace Weather.Core.Domain
{
    public class DeviceDataItem
    {
        /// <summary>
        /// Datetime, int (milliseconds from 01-01-1970, rounded down to nearest minute on server)
        /// </summary>
        [JsonPropertyName("dateutc")]
        public long DateUtc { get; set; }

        /// <summary>
        /// Indoor Temperature, ºF
        /// </summary>
        [JsonPropertyName("tempinf")]
        public double TempIn { get; set; }

        /// <summary>
        /// Indoor Humidity, 0-100%
        /// </summary>
        [JsonPropertyName("humidityin")]
        public int HumidityIn { get; set; }

        /// <summary>
        /// Relative Pressure, inHg
        /// </summary>
        [JsonPropertyName("baromrelin")]
        public double BaromRel { get; set; }

        /// <summary>
        /// Absolute Pressure, inHg
        /// </summary>
        [JsonPropertyName("baromabsin")]
        public double BaromAbs { get; set; }

        /// <summary>
        /// Outdoor Temperature, ºF
        /// </summary>
        [JsonPropertyName("tempf")]
        public double TempOut { get; set; }

        /// <summary>
        /// Outdoor Battery - OK/Low indication, Int, 1=OK, 0=Low (Meteobridge Users 1=Low, 0=OK)
        /// </summary>
        [JsonPropertyName("battout")]
        public bool BattOut { get; set; }

        /// <summary>
        /// Outdoor Humidity, 0-100%
        /// </summary>
        [JsonPropertyName("humidity")]
        public int HumidityOut { get; set; }

        /// <summary>
        ///  instantaneous wind direction, 0-360º
        /// </summary>
        [JsonPropertyName("winddir")]
        public int WindDir { get; set; }

        /// <summary>
        /// instantaneous wind speed, mph
        /// </summary>
        [JsonPropertyName("windspeedmph")]
        public double WindSpeed { get; set; }

        /// <summary>
        /// max wind speed in the last 10 minutes, mph
        /// </summary>
        [JsonPropertyName("windgustmph")]
        public double WindGust { get; set; }

        /// <summary>
        /// Maximum wind speed in last day, mph
        /// </summary>
        [JsonPropertyName("maxdailygust")]
        public double MaxDailyGust { get; set; }

        /// <summary>
        /// Hourly Rain Rate, inches/hr
        /// </summary>
        [JsonPropertyName("hourlyrainin")]
        public double HourlyRainRate { get; set; }

        /// <summary>
        /// Event Rain, inches
        /// </summary>
        [JsonPropertyName("eventrainin")]
        public double EventRain { get; set; }

        /// <summary>
        /// Daily Rain, inches
        /// </summary>
        [JsonPropertyName("dailyrainin")]
        public double DailyRain { get; set; }

        /// <summary>
        /// Weekly Rain, inches
        /// </summary>
        [JsonPropertyName("weeklyrainin")]
        public double WeeklyRain { get; set; }

        /// <summary>
        /// Monthly Rain, inches
        /// </summary>
        [JsonPropertyName("monthlyrainin")]
        public double MonthlyRain { get; set; }

        /// <summary>
        /// Total Rain, inches (since last factory reset)
        /// </summary>
        [JsonPropertyName("totalrainin")]
        public double TotalRain { get; set; }

        /// <summary>
        /// Solar Radiation, W/m^2
        /// </summary>
        [JsonPropertyName("solarradiation")]
        public double SolarRadiation { get; set; }

        /// <summary>
        /// Ultra-Violet Radiation Index
        /// </summary>
        [JsonPropertyName("uv")]
        public int Uv { get; set; }

        /// <summary>
        /// CO2 battery - 1=OK, 0=Low
        /// </summary>
        [JsonPropertyName("batt_co2")]
        public bool BattCo2 { get; set; }

        /// <summary>
        /// if < 50ºF => Wind Chill, if > 68ºF => Heat Index (calculated on server)
        /// </summary>
        [JsonPropertyName("feelsLike")]
        public double FeelsLike { get; set; }

        /// <summary>
        /// Indoor Feels Like
        /// </summary>
        [JsonPropertyName("dewPoint")]
        public double DewPoint { get; set; }

        /// <summary>
        /// Indoor Feels Like
        /// </summary>
        [JsonPropertyName("feelsLikein")]
        public double FeelsLikeIn { get; set; }

        /// <summary>
        /// Dew Point, ºF (calculated on server)
        /// </summary>
        [JsonPropertyName("dewPointin")]
        public double DewPointIn { get; set; }

        [JsonPropertyName("loc")]
        public string Loc { get; set; } = "";

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
    }
}
