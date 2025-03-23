

using Core.DataAccess.Repositories;
using MoviProject.Model.Entities;

namespace MoviProject.DataAccess.Repositories.Abstracts;

public interface IMovieRepository: IRepository<Movie,Guid>
{

}
