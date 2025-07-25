﻿


using Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Core.DataAccess.Repositories;

public abstract class EfRepositoryBase<TEntity, TId,TContext> :IRepository<TEntity,TId>,IAsyncRepository<TEntity,TId>
    where TEntity : Entity<TId>
    where TContext:DbContext
{
    protected TContext Context { get; }

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public TEntity Add(TEntity entity)
    {
        entity.CreatedTime = DateTime.Now;
       
        Context.Entry(entity).State=EntityState.Added;
        Context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Deleted;
        Context.SaveChanges();
        return entity;  
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null,bool include = true, bool enableTracking = true)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

        if(filter is not null )
        {
            query = query.Where(filter);
        }

        if (enableTracking is false)
        {
            query= query.AsNoTracking();
        }


        if (include is false)
        {
            query = query.IgnoreAutoIncludes();
        }

        return query.ToList();
    }

    public TEntity? GetById(TId id)
    {
        return Context.Set<TEntity>().Find(id); 
    }

    public TEntity Update(TEntity entity)
    {
        entity.UpdateTime = DateTime.Now;
        //Context.Category
        Context.Entry(entity).State = EntityState.Modified;
        Context.SaveChanges();
        return entity;
    }
    

    public IQueryable<TEntity> Query()
    {
        return Context.Set<TEntity>();
    }

    public TEntity? Get(Expression<Func<TEntity, bool>>? filter, bool include = true, bool enableTracking = true)
    {
       IQueryable<TEntity> query = Query();

        if (include is not false)
        {
            query = query.IgnoreAutoIncludes();

        }

        if (enableTracking is false)
        {
            query = query.AsNoTracking();
        }

        return query.FirstOrDefault(filter);
    }

    public bool Any(Expression<Func<TEntity, bool>>? filter = null, bool enableTracking = true)
    {
        IQueryable<TEntity> query = Query();

        

        if (enableTracking is false)
        {
            query = query.AsNoTracking();
        }

        if (filter is not null)
        {
            return query.Any(filter);
        }

        return query.Any();
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.CreatedTime = DateTime.Now;

        Context.Entry(entity).State = EntityState.Added;
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<TEntity> UpdateAsyn(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.UpdateTime = DateTime.Now;
        //Context.Category
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Context.Entry(entity).State = EntityState.Deleted;
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, bool include = true, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

        if (filter is not null)
        {
            query = query.Where(filter);
        }

        if (enableTracking is false)
        {
            query = query.AsNoTracking();
        }


        if (include is false)
        {
            query = query.IgnoreAutoIncludes();
        }

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>>? filter, bool include = true, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = Query();

        if (include is not false)
        {
            query = query.IgnoreAutoIncludes();

        }

        if (enableTracking is false)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(filter);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null, bool enableTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = Query();



        if (enableTracking is false)
        {
            query = query.AsNoTracking();
        }

        if (filter is not null)
        {
            return await query.AnyAsync(filter,cancellationToken);
        }

        return await query.AnyAsync(cancellationToken);
    }
}
