namespace EntityFrameworkSample.Entities;

public class BaseEntity<Key>
{
    public Key Id { get; set; }
    public bool IsActive { get; set; } = true;
}