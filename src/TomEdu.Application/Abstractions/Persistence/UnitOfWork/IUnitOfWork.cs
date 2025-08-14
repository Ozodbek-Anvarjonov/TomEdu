namespace TomEdu.Application.Abstractions.Persistence.UnitOfWork;

public interface IUnitOfWork : ITransactionManager, IDisposable, IAsyncDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}