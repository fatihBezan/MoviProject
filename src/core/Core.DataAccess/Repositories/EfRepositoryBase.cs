


using Core.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.Repositories;

public abstract class EfRepositoryBase<TEntity, TId,TContext> :IRepository<TEntity,TId>
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

    public List<TEntity> GetAll(bool include = true)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();
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
}
