using EntityFrameworkSample.Data;
using EntityFrameworkSample.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkSample.Services.ProductService;

public class ProductRepository(SampleContext context) : 
    //BaseRepositoryAsync<ProductRepository>(context),
    IProductRepository
{
    private readonly SampleContext _context = context;

    public async Task<object> GetAllAsync()
    {
        try
        {
            var result = await _context.Products
                .ToListAsync();
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return "error";
        }
    }

    public async Task<object> GetListPaginationAsync(int pageNumber, int pageSize)
    {
        try
        {
            var result = await _context.Products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return "error";
        }
    }

    public async Task<object> GetById(Guid id)
    {
        try
        {
            var result = await _context.Products
                .FindAsync(id);
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return "error";
        }
    }

    public async Task<object> AddAsync(Product entity)
    {
        try
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return "error";
        }
    }

    public async Task<object> UpdateAsync(Product entity)
    {
        try
        {
            //var hasRecord = await _context.Set<T>()
            //.FindAsync(entity);

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return "error";
        }
    }

    public async Task<object> DeleteAsync(Guid id)
    {
        try
        {
            var hasRecord = await _context.Products
                .FindAsync(id);
            if (hasRecord is null)
                return "Not Found";

            _context.Entry(hasRecord).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return $"id: {id}";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return "error";
        }
    }
}