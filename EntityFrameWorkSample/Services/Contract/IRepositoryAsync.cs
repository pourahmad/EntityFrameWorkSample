namespace EntityFrameworkSample.Services.Contract;

public interface IRepositoryAsync<T> where T : class
{
    Task<object> GetAllAsync();
    Task<object> GetListPaginationAsync(int pageNumber, int pageSize);
    Task<object> GetById(Guid id);

    Task<object> AddAsync(T entity);
    Task<object> UpdateAsync(T entity);
    Task<object> DeleteAsync(Guid id);
}