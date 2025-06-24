using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Service.Abstracts;
using MovieProject.Service.Concretes;
using MoviProject.DataAccess.Contexts;
using MoviProject.Model.Dtos.Categories;

namespace MovieProject.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    //constroctor arg injection
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)// dependency injection
    {
        _categoryService = categoryService;
    }

    //property injection

    //public ICategoryService CategoryService { get; set; }
    //metot injection
    [HttpPost("add")]
    public IActionResult Add(CategoryAddRequestDto dto) 
    {
        try
        {
            _categoryService.Add(dto);

            return Ok("kategori başarı ile eklendi");
        }
        catch (BusinessException ex)
        {

            return BadRequest(ex.Message);
        }
       
    }


    [HttpGet("getall")]
    public IActionResult GetAll()  
    { 
        var response=_categoryService.GetAll();

        return Ok(response);
    }


    [HttpGet("getbyid")]
    public IActionResult GetById(int id) 
    {
        try
        {
            var response = _categoryService.GetById(id);
            return Ok(response);

        }
        catch (NotFoundException ex) 
        {
            return NotFound(ex.Message);
        }

        
    }

    [HttpPut("update")]

    public IActionResult Update(CategoryUpdateRequestDto dto) 
    {
        try
        {
            _categoryService.Update(dto);
            return Ok("Kategori güncellendi");

        }
        catch (NotFoundException ex)
        {

            return NotFound(ex.Message);
        }
    }

    [HttpDelete("delete")]
    public IActionResult Delete(int id)  
    {

        try
        {
            _categoryService.Delete(id);
            return Ok("kategori silindi");
        }
        catch (NotFoundException ex)
        {

            return NotFound(ex.Message);
        }
        
    }
}
