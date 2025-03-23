

using Core.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using MoviProject.DataAccess.Contexts;
using MoviProject.DataAccess.Repositories.Abstracts;
using MoviProject.Model.Entities;

namespace MovieProject.DataAccess.Repositories.Concretes;

public sealed class CategoryRepository : EfRepositoryBase<Category, int, BaseDbContext>, ICategoryRepository
{

    public CategoryRepository(BaseDbContext context) : base(context)
    {

    }




    //public Category Add(Category entity)
    //{
    //    entity.CreatedTime = DateTime.UtcNow;
    //    _dbContext.Categories.Add(entity);
    //    _dbContext.SaveChanges();

    //    return entity;
    //}

    //public Category Delete(Category entity)
    //{
    //    _dbContext.Categories.Remove(entity);
    //    _dbContext.SaveChanges();

    //    return entity;
    //}

    //public List<Category> GetAll()
    //{
    //    return _dbContext.Categories.ToList();
    //}

    //public Category? GetById(int id)
    //{
    //    return _dbContext.Categories.Find(id);
    //}

    //public Category Update(Category entity)
    //{
    //    entity.UpdateTime = DateTime.UtcNow;
    //    _dbContext.Categories.Update(entity);
    //    _dbContext.SaveChanges();

    //    return entity;
    //}

}
