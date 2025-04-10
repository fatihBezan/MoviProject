using MoviProject.Model.Dtos.Categories;
using MoviProject.Model.Entities;

namespace MovieProject.Service.Mappers.Categories;

//polimorfizim de classlar birbiri üzerinde dönüşüm sağlayabiliyorsa  ->dynamic polimorfizim
//overloding->static polymorphism

public sealed class ManuelCategoryMapper:ICategoryMapper
{
    public Category ConvertToEntity(CategoryAddRequestDto dto)
    {
        return new Category
        {
            Name = dto.Name
        };
    }

    public Category ConvertToEntity(CategoryUpdateRequestDto dto)
    {
        return new Category
        {
            Id = dto.Id,
            Name = dto.Name,
        };
    }
    public CategoryResponseDto ConvertToResponse(Category category)
    {
        return new CategoryResponseDto(category.Id, category.Name);
    }

    public List<CategoryResponseDto> ConvertToResponseList(List<Category> categories)
    {
        // List<CategoryResponseDto> responseDtos = new();
        // foreach (var category in categories)
        // {
        //     //CategoryResponseDto responseDto = ConvertToResponse(category);
        //     responseDtos.Add(ConvertToResponse(category));
        // }

        //return responseDtos;

        return categories.Select(x => ConvertToResponse(x)).ToList();
    }
}
