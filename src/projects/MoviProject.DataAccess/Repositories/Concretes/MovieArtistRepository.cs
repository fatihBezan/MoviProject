

using Core.DataAccess.Repositories;
using MoviProject.DataAccess.Contexts;
using MoviProject.DataAccess.Repositories.Abstracts;
using MoviProject.Model.Entities;

namespace MovieProject.DataAccess.Repositories.Concretes;

public sealed class MovieArtistRepository : EfRepositoryBase<MovieArtist, long, BaseDbContext>, IMovieArtistRepository
{
    public MovieArtistRepository(BaseDbContext context) : base(context)
    {
    }
}