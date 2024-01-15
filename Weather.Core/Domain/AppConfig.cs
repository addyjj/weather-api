using Microsoft.Extensions.Configuration;

namespace Weather.Core.Domain;

public class AppConfig(IConfiguration config)
{
    public string AmbientApiKey { get; } = config["Ambient:ApiKey"] ?? "";
    public string AmbientApplicationKey { get; } = config["Ambient:ApplicationKey"] ?? "";
    public Uri AmbientWeatherApiUrl { get; } = new(config["Ambient:ApiUrl"] ?? "");
    public string AmbientDeviceMacAddress { get; } = config["Ambient:DeviceMacAddress"] ?? "";
    public string SqlConnectionString { get; } = config.GetConnectionString("sql") ?? "";
}