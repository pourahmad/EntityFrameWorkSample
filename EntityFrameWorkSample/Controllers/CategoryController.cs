using EntityFrameworkSample.DTOs;
using EntityFrameworkSample.Entities;
using EntityFrameworkSample.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EntityFrameworkSample.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoryController(ICategoryRepository categoryRepository) : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _categoryRepository.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{pageNumber}, {pageSize}")]
    public async Task<IActionResult> Get(int pageNumber, int pageSize)
    {
        var result = await _categoryRepository.GetListPaginationAsync(pageNumber, pageSize);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _categoryRepository.GetById(id);
        return Ok(result);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Get([FromBody]CategoryDto dto)
    {
        var category = new Category()
        {
            Name = dto.Name,
            Description = dto.Description,
            IsActive = true,
        };
        var result = await _categoryRepository.AddAsync(category);
        return Ok(result);
    }
    
    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]CategoryDto dto)
    {
        var category = new Category()
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            IsActive = true,
        };
        var result = await _categoryRepository.UpdateAsync(category);
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _categoryRepository.DeleteAsync(id);
        return Ok(result);
    }
}