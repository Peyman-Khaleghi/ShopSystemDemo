using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopSystem.Domain.Models;

public class Product : IBaseEntity<int>, IAuditLog
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string BrandName { get; set; }
    public string Color { get; set; }
    public string Size { get; set; }
    public decimal Count { get; set; }
    public decimal? Cost { get; set; }
    public string Description { get; set; }
    public bool? HasDiscount { get; set; }
    public string DiscountCode { get; set; }
    public DateTimeOffset? DisCountExpirationDate { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? LastEditDate { get; set; }
    public ProductCategory ProductCategory { get; set; }
    public ICollection<Order> Orders { get; set; }
}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.HasIndex(p => p.Name).IsUnique();
        builder.Property(p => p.Count).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(4000);

        builder.HasOne(p => p.ProductCategory)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}