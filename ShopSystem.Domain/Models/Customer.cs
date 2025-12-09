using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopSystem.Domain.Models;

public class Customer : IBaseEntity<int>, IAuditLog
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTimeOffset? BirthDate { get; set; }
    public string Address { get; set; }
    public decimal? PostalCode { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? LastEditDate { get; set; }
    public ICollection<Order> Orders { get; set; }
}

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(p => p.FullName).HasMaxLength(300);
    }
}