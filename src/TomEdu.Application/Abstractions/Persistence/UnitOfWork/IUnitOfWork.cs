using TomEdu.Domain.Entities;

namespace TomEdu.Application.Abstractions.Persistence.UnitOfWork;

public interface IUnitOfWork : ITransactionManager, IDisposable, IAsyncDisposable
{
    IRepository<User> Users { get; }
    IRepository<Notification> Notifications { get; }
    IRepository<RefreshToken> RefreshTokens { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}