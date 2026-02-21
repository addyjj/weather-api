using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using SocketIOClient;
using Weather.Core.Options;
using Weather.Infrastructure.Services.External.Dtos;
using Weather.WebApi.Dtos;
using Weather.WebApi.Hubs;

namespace Weather.WebApi.HostedServices;

public class AmbientWeatherService(ILogger<AmbientWeatherService> logger, IOptions<AmbientWeatherOptions> options, IHubContext<WeatherHub> hubContext) : BackgroundService
{
    private readonly SocketIO _socket = new(new Uri(options.Value.SocketUrl), new SocketIOOptions
    {
        Transport = SocketIOClient.Common.TransportProtocol.WebSocket,
        Path = "/socket.io",
        Query = new System.Collections.Specialized.NameValueCollection
        {
            ["api"] = "1",
            ["applicationKey"] = options.Value.ApplicationKey
        }
    });

    private readonly string _apiKey = options.Value.ApiKey;

    public async Task ConnectAsync()
    {
        _socket.On("subscribed", async (context) =>
        {
            logger.LogInformation("Subscribed to devices");
            await hubContext.Clients.All.SendAsync("subscribed", context);
        });

        _socket.On("data", async (context) =>
        {
            var deviceData = context.GetValue<AmbientWeatherDeviceData>(0);

            if (deviceData is null)
            {
                logger.LogWarning("Received null device data");
                return;
            }

            logger.LogInformation("Received weather data");

            var response = new DeviceDataResponse(deviceData);

            await hubContext.Clients.All.SendAsync("weatherData", response);
        });

        await _socket.ConnectAsync();

        await _socket.EmitAsync("subscribe", [new { apiKeys = new[] { _apiKey } }]);
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await ConnectAsync();
        await Task.Delay(Timeout.Infinite, cancellationToken);
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Stopping the Ambient Weather background service.");
        if (_socket != null)
            await _socket.DisconnectAsync(CancellationToken.None);

        await base.StopAsync(cancellationToken);
    }
}
