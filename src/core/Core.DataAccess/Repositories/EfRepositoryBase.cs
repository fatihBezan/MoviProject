﻿


using Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.Repositories;

public abstract class EfRepositoryBase<TEntity, TId,TContext> : IRepository<TEntity, TId>
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
        //Context.Category
        Context.Set<TEntity>().Add(entity);
        Context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        Context.SaveChanges();
        return entity;  
    }

    public List<TEntity> GetAll()
    {
        return Context.Set<TEntity>().ToList(); 
    }

    public TEntity? GetById(TId id)
    {
        return Context.Set<TEntity>().Find(id); 
    }

    public TEntity Update(TEntity entity)
    {
        entity.UpdateTime = DateTime.Now;
        //Context.Category
        Context.Set<TEntity>().Update(entity);
        Context.SaveChanges();
        return entity;
    }
}
