﻿using System.Linq.Expressions;
using Location.Api.Repositories.Contracts;
using Location.Api.Repositories.EfCore.Config;
using Microsoft.EntityFrameworkCore;

namespace Location.Api.Repositories.EfCore;

// able to use basic CRUD operations in all repos
public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class
{
    protected readonly RepositoryContext _context;

    public RepositoryBase(RepositoryContext context)
    {
        _context = context;
    }


    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        return !trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();
    }


    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges)
    {
        return !trackChanges ? _context.Set<T>().Where(expression).AsNoTracking() : _context.Set<T>().Where(expression);
    }
}