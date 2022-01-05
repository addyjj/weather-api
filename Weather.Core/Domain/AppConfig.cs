namespace Weather.Core.Domain
{
    public class AppConfig
    {
        public string AmbientApiKey { get; set; }
        public string AmbientApplicationKey { get; set; }
        public Uri AmbientWeatherApiUrl { get; set; }
        public string AmbientDeviceMacAddress { get; set; }
        public string SqlConnectionString { get; set; }
    }
}
