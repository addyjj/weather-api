using Microsoft.Extensions.Options;
using Weather.Core.Options;

namespace Weather.Infrastructure.Services.External;

public class AmbientWeatherHttpHandler(IOptions<AmbientWeatherOptions> options) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var uri = new UriBuilder(request.RequestUri!)
        {
            Query = $"apiKey={options.Value.ApiKey}&applicationKey={options.Value.ApplicationKey}"
        };
        request.RequestUri = uri.Uri;

        return await base.SendAsync(request, cancellationToken);
    }
}
