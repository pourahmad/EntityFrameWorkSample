using EntityFrameworkSample.Entities;

namespace EntityFrameworkSample.Services.CategoryService;

public interface ICategoryRepository //: IRepositoryAsync<Category>
{
    Task<object> GetAllAsync();
    Task<object> GetListPaginationAsync(int pageNumber, int pageSize);
    Task<object> GetById(Guid id);

    Task<object> AddAsync(Category entity);
    Task<object> UpdateAsync(Category entity);
    Task<object> DeleteAsync(Guid id);
}