namespace Weather.Core.Interfaces;

public interface ICacheService
{
    Task<TItem> GetOrCreateAsync<TItem>(
        string key,
        Func<CancellationToken, Task<TItem>> factory,
        TimeSpan? absoluteExpirationRelativeToNow = null,
        CancellationToken cancellationToken = default);

    void Remove(string key);
}
