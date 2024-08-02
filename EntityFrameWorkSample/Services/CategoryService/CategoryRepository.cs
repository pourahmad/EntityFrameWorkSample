using EntityFrameworkSample.Data;
using EntityFrameworkSample.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkSample.Services.CategoryService;

public class CategoryRepository(SampleContext context) :
    //BaseRepositoryAsync<Category>(_context),
    ICategoryRepository
{
    private readonly SampleContext _context = context;

    public async Task<object> GetAllAsync()
    {
        try
        {
            var result = await _context.Categories
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
            var result = await _context.Categories
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
            var result = await _context.Categories
                .Where(w => w.Id == id)
                .Include(i => i.Products)
                .FirstOrDefaultAsync();
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Category();
        }
    }
    
    public async Task<object> AddAsync(Category entity)
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

    public async Task<object> UpdateAsync(Category entity)
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
            var hasRecord = await _context.Categories
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