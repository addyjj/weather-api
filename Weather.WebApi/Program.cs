using Weather.WebApi.Setup;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder
    .Configuration
    .AddUserSecrets<Program>(true)
    .AddEnvironmentVariables();

// Add services
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddAmbientWeather(builder.Configuration);
builder.Services.AddCoreServices();
builder.Services.AddODataConfiguration();
builder.Services.AddCorsConfiguration();
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