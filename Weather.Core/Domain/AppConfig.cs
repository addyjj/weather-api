using Microsoft.Extensions.Configuration;

namespace Weather.Core.Domain
{
    public class AppConfig
    {
        public AppConfig(IConfiguration config)
        {
            AmbientApiKey = config["Ambient:ApiKey"] ?? "";
            AmbientApplicationKey = config["Ambient:ApplicationKey"] ?? "";
            AmbientWeatherApiUrl = new Uri(config["Ambient:ApiUrl"] ?? "");
            AmbientDeviceMacAddress = config["Ambient:DeviceMacAddress"] ?? "";
            SqlConnectionString = config.GetConnectionString("sql") ?? "";
        }
        public string AmbientApiKey { get; }
        public string AmbientApplicationKey { get; }
        public Uri AmbientWeatherApiUrl { get; }
        public string AmbientDeviceMacAddress { get; }
        public string SqlConnectionString { get; }
    }
}
