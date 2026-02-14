using Microsoft.Extensions.Caching.Memory;
using Weather.Core.Interfaces;

namespace Weather.Infrastructure.Services.Cache;

public class MemoryCacheService(IMemoryCache cache) : ICacheService
{
    private static readonly TimeSpan DefaultCacheDuration = TimeSpan.FromMinutes(5);

    public Task<TItem> GetOrCreateAsync<TItem>(
        string key,
        Func<CancellationToken, Task<TItem>> factory,
        TimeSpan? absoluteExpirationRelativeToNow = null,
        CancellationToken cancellationToken = default)
    {
        return cache.GetOrCreateAsync(key, entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow ?? DefaultCacheDuration;
            return factory(cancellationToken);
        })!;
    }

    public void Remove(string key)
    {
        cache.Remove(key);
    }
}
