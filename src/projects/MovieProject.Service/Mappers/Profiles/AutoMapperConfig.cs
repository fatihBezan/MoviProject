

using AutoMapper;
using MoviProject.Model.Dtos.Categories;
using MoviProject.Model.Dtos.MovieArtists;
using MoviProject.Model.Dtos.Movies;
using MoviProject.Model.Entities;

namespace MovieProject.Service.Mappers.Profiles;

public class AutoMapperConfig:Profile
{
    public AutoMapperConfig()
    {
        CreateMap<CategoryAddRequestDto, Category>();

        CreateMap<CategoryUpdateRequestDto, Category>();

        CreateMap<Category, CategoryResponseDto>();

        CreateMap<MovieAddRequestDto, Movie>();
        CreateMap<Movie,MovieResponseDto>();


    }
}
