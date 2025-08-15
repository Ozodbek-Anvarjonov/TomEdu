using System.Linq.Expressions;
using TomEdu.Domain.Common.Entities;

namespace TomEdu.Application.Abstractions.Persistence;

public interface IRepository<TEntity>
    where TEntity : IEntity
{
    IQueryable<TEntity> Get(
        Expression<Func<TEntity, bool>>? predicate = default,
        bool asNoTracking = false,
        string[]? includes = default
        );

    Task<TEntity?> GetByIdAsync(
        long id,
        bool asNoTracking = false,
        string[]? includes = default,
        CancellationToken cancellationToken = default
        );

    Task<long> CreateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default);

    Task UpdateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default);

    Task DeleteAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}