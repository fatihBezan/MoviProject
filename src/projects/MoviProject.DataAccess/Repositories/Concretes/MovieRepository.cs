

using Core.DataAccess.Repositories;
using MoviProject.DataAccess.Contexts;
using MoviProject.DataAccess.Repositories.Abstracts;
using MoviProject.Model.Entities;

namespace MovieProject.DataAccess.Repositories.Concretes;

public sealed class MovieRepository : EfRepositoryBase<Movie, Guid, BaseDbContext>, IMovieRepository
{
    public MovieRepository(BaseDbContext context) : base(context)
    {
    }
}