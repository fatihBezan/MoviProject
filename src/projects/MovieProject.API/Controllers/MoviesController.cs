using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Service.Abstracts;
using MoviProject.Model.Dtos.Movies;

namespace MovieProject.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpPost("add")]

    public IActionResult Add(MovieAddRequestDto dto)
    {
        var result = _movieService.Add(dto);

        return Ok(result);

    }

    [HttpGet("getall")]
    public IActionResult GetAll() 
    {
        var result =_movieService.GetAll();
        return Ok(result);  
    }
}
