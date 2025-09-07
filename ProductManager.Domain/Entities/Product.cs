namespace ProductManager.Domain.Entities;

public class Product : AuditableEntity
{
    public string Name { get; set; }
}