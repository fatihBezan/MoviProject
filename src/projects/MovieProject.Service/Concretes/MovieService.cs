
using AutoMapper;
using MovieProject.Service.Abstracts;
using MoviProject.DataAccess.Repositories.Abstracts;
using MoviProject.Model.Dtos.Movies;

namespace MovieProject.Service.Concretes;

public sealed class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private IMapper _mapper;

    public MovieService(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public void Add(MovieAddRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<MovieResponseDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<MovieResponseDto> GetAllByCategory(int id)
    {
        throw new NotImplementedException();
    }

    public List<MovieResponseDto> GetAllByDirectorId(long id)
    {
        throw new NotImplementedException();
    }

    public List<MovieResponseDto> GetAllByIsActive(bool active)
    {
        throw new NotImplementedException();
    }

    public List<MovieResponseDto> GetAllImdbRange(double min, double max)
    {
        throw new NotImplementedException();
    }

    public MovieResponseDto? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(MovieUpdateRequestDto dto)
    {
        throw new NotImplementedException();
    }
}
