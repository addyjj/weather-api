using Microsoft.AspNetCore.SignalR;

namespace Weather.WebApi.Hubs;

public class WeatherHub(ILogger<WeatherHub> logger) : Hub
{
    public override async Task OnConnectedAsync()
    {
        logger.LogInformation("Client {ConnectionId} connected to Weather Hub", Context.ConnectionId);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        logger.LogInformation("Client {ConnectionId} disconnected from Weather Hub", Context.ConnectionId);
        await base.OnDisconnectedAsync(exception);
    }
}
