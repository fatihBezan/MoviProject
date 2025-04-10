

using MoviProject.Model.Dtos.Categories;
using MoviProject.Model.Entities;

namespace MovieProject.Service.Mappers.Categories;

public interface ICategoryMapper
{
    Category ConvertToEntity(CategoryAddRequestDto dto);

    Category ConvertToEntity(CategoryUpdateRequestDto dto);

    CategoryResponseDto ConvertToResponse(Category category);

    List<CategoryResponseDto> ConvertToResponseList(List<Category> categories);

}
