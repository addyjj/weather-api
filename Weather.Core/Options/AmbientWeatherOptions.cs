namespace Weather.Core.Options;

public class AmbientWeatherOptions
{
    public string ApiKey { get; set; } = "";
    public string ApplicationKey { get; set; } = "";
    public string ApiUrl { get; set; } = "";
    public string DeviceMacAddress { get; set; } = "";
    public string SocketUrl { get; set; } = "";
}
