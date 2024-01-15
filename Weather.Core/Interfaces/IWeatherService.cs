namespace Weather.Core.Interfaces;

public interface IWeatherService
{
    Task ImportAsync(string macAddress);
}