

using Microsoft.AspNetCore.Http;
using MoviProject.Model.Dtos.Movies;

namespace MovieProject.Service.Abstracts;

public interface IMovieService
{
    string Add(MovieAddRequestDto dto);  

    void Update(MovieUpdateRequestDto dto);

    void Delete(int id);

    List<MovieResponseDto> GetAll();    

    MovieResponseDto? GetById(int id);

    List<MovieResponseDto> GetAllByCategory(int id);

    List<MovieResponseDto> GetAllByDirectorId(long id);

    List<MovieResponseDto> GetAllImdbRange(double min,double max);

    List<MovieResponseDto> GetAllByIsActive(bool active);

}
