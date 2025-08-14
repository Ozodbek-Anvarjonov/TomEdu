using TomEdu.Application.Abstractions.Caching.Models;

namespace TomEdu.Application.Abstractions.Caching.Brokers;

public interface ICacheBroker
{
    ValueTask<TEntity?> GetAsync<TEntity>(string key, CancellationToken cancellationToken = default);

    ValueTask<bool> TryGetAsync<TEntity>(string key, out TEntity? entity, CancellationToken cancellationToken = default);

    ValueTask<TEntity?> GetOrSetAsync<TEntity>(
        string key,
        Func<Task<TEntity>> valueFactory,
        CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default
        );

    ValueTask SetAsync<TEntity>(
        string key,
        TEntity entity,
        CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default
        );

    ValueTask DeleteAsync(string key, CancellationToken cancellationToken = default);
}