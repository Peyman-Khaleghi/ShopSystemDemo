using Microsoft.EntityFrameworkCore;
using ShopSystem.Domain.Models;

namespace ShopSystem.infrastructure.AppDbContext;

public class ShopSystemDbContext : DbContext
{
    public ShopSystemDbContext(DbContextOptions<ShopSystemDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var entityAssembly = typeof(Product).Assembly;

        var entityTypes = entityAssembly
            .GetTypes()
            .Where(t => typeof(IBaseEntity).IsAssignableFrom(t)
                        && t.IsClass && !t.IsAbstract);

        foreach (var type in entityTypes)
        {
            var entity = modelBuilder.Entity(type);

            entity.HasKey("Id");
        }
        base.OnModelCreating(modelBuilder);
    }
}