using EntityFrameworkSample.Entities.StoredProcedure;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkSample.Data;

public partial class SampleContext
{
    #region GetSumPriceAtEachCategories

    public DbSet<SumPriceAtEachCategory> SumPriceAtEachCategories { get; set; }
    public DbSet<SumPriceAtEachCategoryWithPrice> SumPriceAtEachCategoryWithPrices { get; set; }

    #endregion GetSumPriceAtEachCategories
}