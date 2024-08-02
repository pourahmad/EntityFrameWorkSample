using EntityFrameworkSample.Entities;
using EntityFrameworkSample.Services.Contract;

namespace EntityFrameworkSample.Services.ProductService;

public interface IProductRepository //: IRepositoryAsync<ProductRepository>
{
    Task<object> GetAllAsync();
    Task<object> GetListPaginationAsync(int pageNumber, int pageSize);
    Task<object> GetById(Guid id);

    Task<object> AddAsync(Product entity);
    Task<object> UpdateAsync(Product entity);
    Task<object> DeleteAsync(Guid id);
}