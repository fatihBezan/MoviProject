
using Core.DataAccess.Repositories;
using MoviProject.Model.Entities;

namespace MoviProject.DataAccess.Repositories.Abstracts;

public interface IDirectorRepository: IRepository<Director,long>,IAsyncRepository<Director,long>
{
 
}
