using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Weather.Core.Domain;
using Weather.Core.Options;
using Weather.Infrastructure.Ioc;

var builder = WebApplication.CreateBuilder(args);

// configuration
builder
    .Configuration
    .AddUserSecrets<Program>(true)
    .AddEnvironmentVariables();

// Configure options
builder.Services.Configure<AmbientWeatherOptions>(
    builder.Configuration.GetSection("Ambient"));

builder.Services.Configure<DatabaseOptions>(options =>
{
    options.ConnectionString = builder.Configuration.GetConnectionString("sql") ?? "";
});

// Add services to the container.
builder.Services
    .AddControllers()
    .AddOData(opt =>
    {
        opt.AddRouteComponents("odata", GetEdmModel());
        opt.Select().Count().Filter().OrderBy().SetMaxTop(100);
    });

// Register services using extension method
builder.Services.RegisterServices();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EnableLowerCamelCase();
    builder.EntityType<DeviceDataItem>().HasKey(x => x.DateUtc);
    builder.EntitySet<DeviceDataItem>("History");
    return builder.GetEdmModel();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();