using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopSystem.Domain.Models;

public class Order : IBaseEntity, IAuditLog
{
    public int Id { get; set; }
    public long Number { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public OrderStatus Status { get; set; }
    public string Description { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? LastEditDate { get; set; }
    public Customer Customer { get; set; }
    public Product Product { get; set; }
}

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(p => p.Number).IsRequired();
        builder.Property(p => p.CustomerId).IsRequired();
        builder.Property(p => p.ProductId).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(4000);

        builder.HasOne(p => p.Customer)
            .WithMany(p => p.Orders)
            .HasForeignKey(p => p.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Product)
            .WithMany(p => p.Orders)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

public enum OrderStatus
{
    Processing = 1,
    Delivered = 2
}