using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Weather.Core.Domain;

namespace Weather.WebApi.Setup;

public static class ODataSetup
{
    public static IServiceCollection AddODataConfiguration(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddOData(opt =>
            {
                opt.AddRouteComponents("odata", GetEdmModel());
                opt.Select().Count().Filter().OrderBy().SetMaxTop(100);
            });

        return services;
    }

    private static IEdmModel GetEdmModel()
    {
        var builder = new ODataConventionModelBuilder();
        builder.EnableLowerCamelCase();
        builder.EntityType<DeviceDataItem>().HasKey(x => x.DateUtc);
        builder.EntitySet<DeviceDataItem>("History");
        return builder.GetEdmModel();
    }
}
