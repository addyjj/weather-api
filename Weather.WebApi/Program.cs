using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Weather.Core.Domain;
using Weather.Core.Interfaces;
using Weather.Core.Services;
using Weather.Infrastructure.Entity;
using Weather.Infrastructure.Entity.Contexts;
using Weather.Infrastructure.Rest;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets<Program>();

// Add services to the container.
builder.Services
    .AddControllers()
    .AddOData(opt => {
        opt.AddRouteComponents("odata", GetEdmModel());
        opt.Select().Count().Filter().SetMaxTop(100);
    });

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EnableLowerCamelCase();
    builder.EntityType<DeviceDataItem>().HasKey(x => x.DateUtc);
    builder.EntitySet<DeviceDataItem>("History");
    return builder.GetEdmModel();
}

// Config
builder.Services.AddSingleton<AppConfig>();

// Context
builder.Services.AddTransient<WeatherContext>();

// Services
builder.Services.AddTransient<IWeatherService, WeatherService>();

// Repositories
builder.Services.AddTransient<IAmbientWeatherRepository, AmbientWeatherRepository>();
builder.Services.AddTransient<IWeatherDataRepository, WeatherDataRepository>();

// HTTP Client
builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();