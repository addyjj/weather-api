using Microsoft.Extensions.Options;
using System.Web;
using Weather.Core.Options;

namespace Weather.Infrastructure.Rest;

public class AmbientWeatherHttpHandler(IOptions<AmbientWeatherOptions> options) : DelegatingHandler
{
    private readonly AmbientWeatherOptions _options = options.Value;

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.RequestUri == null)
        {
            return base.SendAsync(request, cancellationToken);
        }

        var uriBuilder = new UriBuilder(request.RequestUri);

        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["apiKey"] = _options.ApiKey;
        query["applicationKey"] = _options.ApplicationKey;

        uriBuilder.Query = query.ToString();
        request.RequestUri = uriBuilder.Uri;

        return base.SendAsync(request, cancellationToken);
    }
}
