namespace ProductManager.Domain.Entities;

public class AuditableEntity
{
    public int Id { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime?  LastModifyTime { get; set; }
}