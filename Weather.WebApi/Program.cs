using Weather.Infrastructure.Extensions;
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

var app = builder.Build();

// Configure pipeline
app.UseOpenApi();
app.UseCorsConfiguration();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHealthCheckEndpoints();

app.Run();