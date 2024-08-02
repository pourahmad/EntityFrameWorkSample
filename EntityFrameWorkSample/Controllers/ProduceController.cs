using EntityFrameworkSample.DTOs;
using EntityFrameworkSample.Entities;
using EntityFrameworkSample.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkSample.Controllers;

[Route("[controller]")]
[ApiController]
public class ProduceController(IProductRepository productRepository) : ControllerBase
{
    private readonly IProductRepository _productRepository = productRepository;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _productRepository.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{pageNumber}, {pageSize}")]
    public async Task<IActionResult> Get(int pageNumber, int pageSize)
    {
        var result = await _productRepository.GetListPaginationAsync(pageNumber, pageSize);
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _productRepository.GetById(id);
        return Ok(result);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Get([FromBody]ProductDto dto)
    {
        var product = new Product()
        {
            Name =dto.Name,
            IsActive = true,
            Price = dto.Price,
            CategoryId = dto.CategoryId,
            ProductionDate = dto.ProductionDate,
            ExpirationDate = dto.ExpirationDate,
        };
        var result = await _productRepository.AddAsync(product);
        return Ok(result);
    }
    
    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]ProductDto dto)
    {
        var product = new Product()
        {
            Id = dto.Id,
            Name =dto.Name,
            IsActive = true,
            Price = dto.Price,
            CategoryId = dto.CategoryId,
            ProductionDate = dto.ProductionDate,
            ExpirationDate = dto.ExpirationDate,
        };
        var result = await _productRepository.UpdateAsync(product);
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _productRepository.DeleteAsync(id);
        return Ok(result);
    }
}