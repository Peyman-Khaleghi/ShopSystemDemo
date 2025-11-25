namespace ShopSystem.Domain.Models;

public interface IBaseEntity
{
    public int Id { get; set; }
}

public interface IAuditLog
{
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? LastEditDate { get; set; }
}