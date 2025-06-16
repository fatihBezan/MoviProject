
using Core.CrossCuttingConcerns.Exceptions;
using MovieProject.Service.Constans.Categories;
using MoviProject.DataAccess.Repositories.Abstracts;

namespace MovieProject.Service.BusinessRules.Categories
{
    //Aynı Kategori ismine sahip bir kategori eklenemez.
    //validasyon kuralları veri tabanına bir sorgu ihtiyacı duyulmaz.
    //Bu kurallar veri tabanına sorgu atılmadan önce çalışır.
    //iş kuralları veri tabanına sorgu atılmasını gerektirir.

    public class CategoryBusinessRules(ICategoryRepository categoryRepository)
    {
        public void CategoryIsPresent(int id)
        {
            bool isPresent = categoryRepository.Any(x => x.Id == id);
            if (!isPresent)
            {
                throw new NotFoundException(CategoryMessages.NotFoundMesage);
            }
        }

        public void CategoryNameIsUnique(string name)
        {
            var category= categoryRepository.Any(x => x.Name.ToLower()== name.ToLower());
            if (category)
            {
                throw new BusinessException(CategoryMessages.CategoryNameIsUniqueMessage);
            }
        }
    }


}
