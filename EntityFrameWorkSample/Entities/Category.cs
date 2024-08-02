﻿namespace EntityFrameworkSample.Entities;

public class Category:BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Product> Products { get; set; }
}