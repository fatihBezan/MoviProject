

using Core.DataAccess.Repositories;
using MoviProject.DataAccess.Contexts;
using MoviProject.DataAccess.Repositories.Abstracts;
using MoviProject.Model.Entities;

namespace MovieProject.DataAccess.Repositories.Concretes;

public sealed class ArtistRepository : EfRepositoryBase<Artist, long, BaseDbContext>, IArtistRepository
{
    public ArtistRepository(BaseDbContext context) : base(context)
    {
    }
}
