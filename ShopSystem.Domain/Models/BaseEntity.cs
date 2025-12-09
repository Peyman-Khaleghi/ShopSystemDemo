namespace ShopSystem.Domain.Models;

public interface IBaseEntity<TId>
{
    public TId Id { get; set; }
}

public interface IAuditLog
{
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? LastEditDate { get; set; }
}