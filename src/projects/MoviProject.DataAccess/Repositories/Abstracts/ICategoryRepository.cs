

using Core.DataAccess.Repositories;
using MoviProject.Model.Entities;

namespace MoviProject.DataAccess.Repositories.Abstracts;


//crud 
public interface ICategoryRepository: IRepository<Category,int>,IAsyncRepository<Category,int>
{
 
}
