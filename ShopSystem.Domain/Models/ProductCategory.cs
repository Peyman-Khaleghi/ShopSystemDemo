using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopSystem.Domain.Models;

public class ProductCategory : IBaseEntity, IAuditLog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? LastEditDate { get; set; }
    public ICollection<Product> Products { get; set; }
}

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.HasIndex(p => p.Name).IsUnique();
    }
}