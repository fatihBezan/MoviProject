

using Core.DataAccess.Repositories;
using MoviProject.DataAccess.Contexts;
using MoviProject.DataAccess.Repositories.Abstracts;
using MoviProject.Model.Entities;

namespace MovieProject.DataAccess.Repositories.Concretes;

public class DirectorRepository : EfRepositoryBase<Director, long, BaseDbContext>, IDirectorRepository
{
    public DirectorRepository(BaseDbContext context) : base(context)
    {
    }

    public List<Director> GetAllByNameContains(string name) 
    { 
        return Context.Directors.Where(x=> x.Name.Contains(name,StringComparison.OrdinalIgnoreCase)).ToList();    
    }


    //private readonly BaseDbContext _dbContext;

    //public DirectorRepository(BaseDbContext dbContext)
    //{
    //    _dbContext = dbContext;
    //}

    //public Director Add(Director entity)
    //{
    //    entity.CreatedTime = DateTime.UtcNow;
    //    _dbContext.Directors.Add(entity);
    //    _dbContext.SaveChanges();

    //    return entity;
    //}

    //public Director Delete(Director entity)
    //{
    //    _dbContext.Directors.Remove(entity);
    //    _dbContext.SaveChanges();

    //    return entity;
    //}

    //public List<Director> GetAll()
    //{
    //    return _dbContext.Directors.ToList();
    //}

    //public List<Director> GetAllByNameContains(string name)
    //{
    //    return _dbContext.Directors.Where(x => x.Name.Contains(name)).ToList();
    //}

    //public Director? GetById(long id)
    //{
    //    // 1. yöntem
    //    return _dbContext.Directors.Find(id);

    //    //2. yöntem
    //    //return _dbContext.Directors.Where(x=>x.Id == id).SingleOrDefault();
    //    //3. yöntem
    //    //return _dbContext.Directors.Where(x => x.Id == id).FirstOrDefault();
    //    //4. yöntem
    //    //return _dbContext.Directors.SingleOrDefault(x => x.Id == id);

    //    //5. yöntem
    //    //return _dbContext.Directors.FirstOrDefault(x => x.Id == id);
    //}

    //public Director Update(Director entity)
    //{
    //    entity.UpdateTime = DateTime.UtcNow;
    //    _dbContext.Directors.Update(entity);
    //    _dbContext.SaveChanges();

    //    return entity;
    //}

}
