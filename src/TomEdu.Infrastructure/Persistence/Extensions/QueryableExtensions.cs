﻿using Microsoft.EntityFrameworkCore;

namespace TomEdu.Infrastructure.Persistence.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> ApplyInclude<TEntity>(this IQueryable<TEntity> src, string[]? includes)
        where TEntity : class
    {
        if (includes is not null)
            foreach (var include in includes)
                src = src.Include(include);

        return src;
    }
}