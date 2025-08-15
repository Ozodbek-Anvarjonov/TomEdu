using Microsoft.EntityFrameworkCore;
using TomEdu.Application.Abstractions.Identity;
using TomEdu.Application.Abstractions.Persistence;
using TomEdu.Application.Common.Exceptions;
using TomEdu.Application.Common.Filters;
using TomEdu.Application.Common.Responses;
using TomEdu.Application.Services;
using TomEdu.Domain.Entities;
using TomEdu.Domain.Enums;
using TomEdu.Infrastructure.Extensions;

namespace TomEdu.Infrastructure.Services;

public class UserService(
    IRepository<User> repository,
    IHeaderWriter writer,
    IPasswordHasherService passwordHasherService
    ) : IUserService
{
    public Task<IEnumerable<User>> GetAsync(UserFilter filter, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = repository.Get();

        if (asNoTracking)
            query = query.AsNoTracking();

        if (filter.FirstName is not null)
            query = query.Where(entity => entity.FirstName.ToLower().Contains(filter.FirstName.ToLower()));

        if (filter.LastName is not null)
            query = query.Where(entity => entity.LastName.ToLower().Contains(filter.LastName.ToLower()));

        if (filter.MiddleName is not null)
            query = query.Where(entity => entity.MiddleName != null
                && entity.MiddleName.ToLower().Contains(filter.MiddleName.ToLower()));

        if (filter.EmailAddress is not null)
            query = query.Where(entity => entity.EmailAddress.ToLower().Contains(filter.EmailAddress.ToLower()));

        if (filter.PhoneNumber is not null)
            query = query.Where(entity => entity.PhoneNumber.Contains(filter.PhoneNumber));

        if (filter.Role is not null)
            query = query.Where(entity => entity.Role == filter.Role);

        if (filter.IsActive is not null)
            query = query.Where(entity => entity.IsActive == filter.IsActive);

        return query.ToPaginateAsync(filter, writer, cancellationToken);
    }

    public async Task<User> GetByIdAsync(long id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var exist = await repository.GetByIdAsync(id, asNoTracking, cancellationToken: cancellationToken)
            ?? throw new NotFoundException(nameof(User), nameof(User.Id), id.ToString());

        return exist;
    }

    public async Task<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        user.Password = await passwordHasherService.HashAsync(user.Password, cancellationToken: cancellationToken);

        await repository.CreateAsync(user, saveChanges, cancellationToken);

        return user;
    }

    public async Task<User> UpdateAsync(long id, User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var exist = await GetByIdAsync(id, asNoTracking: false, cancellationToken);

        if (exist.Password is not null)
            exist.Password = await passwordHasherService.HashAsync(user.Password, cancellationToken: cancellationToken);

        await repository.SaveChangesAsync(cancellationToken);

        return exist;
    }

    public async Task<bool> DeleteByIdAsync(long id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var delete = await GetByIdAsync(id, false, cancellationToken);

        if (delete.Role == UserRole.Owner)
            throw new ConflictException("System owner cannot be deleted.");

        await repository.DeleteAsync(delete, cancellationToken: cancellationToken);

        return true;
    }
}