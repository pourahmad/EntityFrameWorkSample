using EntityFrameworkSample.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkSample.Services.CategoryService;

public class CategoryReportRepository(SampleContext context) : ICategoryReportRepository
{
    private readonly SampleContext _context = context;
    
    public async Task<object> GetSumPriceAtEachCategoryAsync()
    {
        var result =
            await _context.SumPriceAtEachCategories
                .FromSqlRaw($"EXECUTE SP_GetSumPriceAtEachCategory")
                .ToListAsync();

        return result;
    }
    
    public async Task<object> GetSumPriceAtEachCategoryAsync(long price)
    {
        var result =
            await _context.SumPriceAtEachCategoryWithPrices
                .FromSqlRaw($"EXECUTE SP_GetSumPriceAtEachCategoryWithPrice @Price = {price}")
                .ToListAsync();

        return result;
    }
}