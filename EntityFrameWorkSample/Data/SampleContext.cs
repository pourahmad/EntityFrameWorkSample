using EntityFrameworkSample.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkSample.Data;

public partial class SampleContext : DbContext
{
    public SampleContext(DbContextOptions<SampleContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasQueryFilter(f => f.IsActive);


        modelBuilder.Entity<Product>().HasQueryFilter(f => f.IsActive);

        modelBuilder.Entity<Product>()
            .HasOne(o => o.Category)
            .WithMany(m => m.Products)
            .HasForeignKey(f => f.CategoryId);

        base.OnModelCreating(modelBuilder);
    }
}