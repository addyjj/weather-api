using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Weather.Infrastructure.Rest
{
    public abstract class RestRepository
    {
        private readonly HttpClient _httpClient;

        protected RestRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public string BearerToken { get; set; } = "";

        protected async Task<T?> GetAsync<T>(string requestUri)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, requestUri);

            if (!string.IsNullOrWhiteSpace(BearerToken))
                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);

            var response = await _httpClient.SendAsync(message).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return await Task.FromResult(default(T));

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }

        protected async Task<T?> PutAsync<T>(string requestUri, object data)
        {
            var message = new HttpRequestMessage(HttpMethod.Put, requestUri);

            if (!string.IsNullOrWhiteSpace(BearerToken))
                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);

            message.Content = new StringContent(JsonSerializer.Serialize(data));
            message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(message).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }

        protected async Task<T?> PostAsync<T>(string requestUri, object data)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, requestUri);

            if (!string.IsNullOrWhiteSpace(BearerToken))
                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);

            message.Content = new StringContent(JsonSerializer.Serialize(data));
            message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(message).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }

        protected async Task<T?> DeleteAsync<T>(string requestUri)
        {
            var message = new HttpRequestMessage(HttpMethod.Delete, requestUri);

            if (!string.IsNullOrWhiteSpace(BearerToken))
                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);

            var response = await _httpClient.SendAsync(message).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }

        protected async Task<T?> SendAsync<T>(HttpRequestMessage message)
        {
            var response = await _httpClient.SendAsync(message).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(content);
        }
    }
}
