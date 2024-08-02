namespace EntityFrameworkSample.Services.CategoryService;

public interface ICategoryReportRepository
{
    Task<object> GetSumPriceAtEachCategoryAsync();
    Task<object> GetSumPriceAtEachCategoryAsync(long price);
}