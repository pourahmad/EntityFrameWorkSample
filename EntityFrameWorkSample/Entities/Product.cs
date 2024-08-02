namespace EntityFrameworkSample.Entities;

public class Product: BaseEntity<Guid>
{
    public string Name { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public long Price { get; set; }
    public DateTime ProductionDate { get; set; }
    public DateTime ExpirationDate { get; set; }
}