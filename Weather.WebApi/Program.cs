using Google.GenAI;
using Microsoft.Extensions.AI;
using Weather.Infrastructure.Extensions;
using Weather.WebApi.HostedServices;
using Weather.WebApi.Hubs;
using Weather.WebApi.Setup;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder
    .Configuration
    .AddUserSecrets<Program>(true)
    .AddEnvironmentVariables();

// Add services
builder.Services.AddControllers();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddHealthCheckServices();
builder.Services.AddCoreServices();
builder.Services.AddCorsConfiguration(builder.Configuration);
builder.Services.AddOpenApi();
builder.Services.AddSignalR();
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
builder.Services.AddChatClient(services =>
{
    var client = new Client(apiKey: "AIzaSyC6BM_TDsWlleFWGIe5-6aBUUe61e6zAfo").AsIChatClient("gemini-2.5-flash");

    return new ChatClientBuilder(client).UseFunctionInvocation().Build();
});
builder.Services.AddHostedService<AmbientWeatherService>();

var app = builder.Build();

// Configure pipeline
app.UseOpenApi();
app.UseCorsConfiguration();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHealthCheckEndpoints();
app.MapHub<WeatherHub>("/weatherHub").RequireCors();

app.Run();