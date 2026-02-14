using Microsoft.Extensions.Options;
using System.Web;
using Weather.Core.Options;

namespace Weather.Infrastructure.Services.External;

public class AmbientWeatherHttpHandler(IOptions<AmbientWeatherOptions> options) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var uri = new UriBuilder(request.RequestUri!);
        var queryParams = HttpUtility.ParseQueryString(uri.Query);

        queryParams["apiKey"] = options.Value.ApiKey;
        queryParams["applicationKey"] = options.Value.ApplicationKey;

        uri.Query = queryParams.ToString();
        request.RequestUri = uri.Uri;

        return await base.SendAsync(request, cancellationToken);
    }
}
