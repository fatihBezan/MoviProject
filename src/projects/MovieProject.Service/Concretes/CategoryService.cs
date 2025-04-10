

using MovieProject.DataAccess.Repositories.Concretes;
using MovieProject.Service.Abstracts;
using MovieProject.Service.Mappers.Categories;
using MoviProject.DataAccess.Contexts;
using MoviProject.DataAccess.Repositories.Abstracts;
using MoviProject.Model.Dtos.Categories;
using MoviProject.Model.Entities;

namespace MovieProject.Service.Concretes;

public sealed class CategoryService : ICategoryService
{
   private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryMapper _categoryMapper;

    public CategoryService(ICategoryRepository categoryRepository, ICategoryMapper categoryMapper)
    {
        _categoryRepository = categoryRepository;
        _categoryMapper = categoryMapper;
    }





    //public CategoryService()
    //{
    //    _categoryRepository = new CategoryRepository(new BaseDbContext());
    //}


    public void Add(CategoryAddRequestDto dto)
    {
        //Category category = new()
        //{
        //    Name = dto.Name
        //} ;
        Category category = _categoryMapper.ConvertToEntity(dto);
        _categoryRepository.Add(category);

    }

    public void Delete(int id)
    {
       var category= _categoryRepository.GetById(id);
        if (category == null) 
        { 
            //to do : exeption fırlat
        }

        _categoryRepository.Delete(category!);
    }

    public List<CategoryResponseDto> GetAll()
    {
        //List<Category> categories = _categoryRepository.GetAll();
        //List<CategoryResponseDto> responses = new List<CategoryResponseDto>();

        //foreach (var item in categories) 
        //{ 
        //    CategoryResponseDto categoryResponseDto = new (item.Id, item.Name);
        //    responses.Add(categoryResponseDto);

        //}
        List<Category> categories = _categoryRepository.GetAll();
        List<CategoryResponseDto> responses = _categoryMapper.ConvertToResponseList(categories);
        return responses;
    }

    public CategoryResponseDto? GetById(int id)
    {
        Category? category=_categoryRepository.GetById(id);
        if (category == null) 
        { 
            //todo : exception fırlat
        }
        //CategoryResponseDto? categoryResponseDto = new(category.Id,category.Name);
        CategoryResponseDto? categoryResponseDto = _categoryMapper.ConvertToResponse(category);
        return categoryResponseDto;
    }

    public void Update(CategoryUpdateRequestDto dto)
    {
        Category? category = _categoryRepository.GetById(dto.Id);
        if(category is  null)
        {
            //todo: exception fırlat
        }
       category.Name=dto.Name;  
        _categoryRepository.Update(category);
    }
}
