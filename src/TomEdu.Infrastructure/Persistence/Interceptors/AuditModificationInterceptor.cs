using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TomEdu.Application.Abstractions.Identity;
using TomEdu.Domain.Common.Entities;

namespace TomEdu.Persistence.Interceptors;

internal class AuditModificationInterceptor(IUserContext userContext) : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var entries = eventData.Context?.ChangeTracker
            .Entries<IAuditableEntity>()
            .Where(entry => entry.State == EntityState.Modified)
            .ToList();

        entries?.ForEach(entry =>
        {
            entry.Entity.ModifiedById = userContext.GetCurrentUserId();
            entry.Entity.ModifiedAt = DateTimeOffset.UtcNow;
        });

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var entries = eventData.Context?.ChangeTracker
            .Entries<IAuditableEntity>()
            .Where(entry => entry.State == EntityState.Modified)
            .ToList();

        entries?.ForEach(entry =>
        {
            entry.Entity.ModifiedById = userContext.GetCurrentUserId();
            entry.Entity.ModifiedAt = DateTimeOffset.UtcNow;
        });

        return base.SavingChanges(eventData, result);
    }
}