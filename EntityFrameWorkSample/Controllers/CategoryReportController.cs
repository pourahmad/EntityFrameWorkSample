using EntityFrameworkSample.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkSample.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoryReportController(ICategoryReportRepository categoryReportRepository) : ControllerBase
{
    private readonly ICategoryReportRepository _categoryReportRepository = categoryReportRepository;
    
    [HttpGet]
    public async Task<IActionResult> GetSumPriceAtEachCategory()
    {
        var result = await _categoryReportRepository
            .GetSumPriceAtEachCategoryAsync();
        
        return Ok(result);
    }
    
    [HttpGet("{price}")]
    public async Task<IActionResult> GetSumPriceAtEachCategory(long price)
    {
        var result = await _categoryReportRepository
            .GetSumPriceAtEachCategoryAsync(price: price);
        
        return Ok(result);
    }
}