using Microsoft.EntityFrameworkCore;
using ShopSystem.Domain.Models;
using System.Reflection;

namespace ShopSystem.infrastructure.AppDbContext;

public class ShopSystemDbContext : DbContext
{
    public ShopSystemDbContext(DbContextOptions<ShopSystemDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var entityTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IBaseEntity).IsAssignableFrom(t)
                        && t.IsClass && !t.IsAbstract);

        foreach (var type in entityTypes)
        {
            var entity = modelBuilder.Entity(type);

            var idProperty = type.GetProperty("Id");
            if (idProperty != null)
            {
                entity.HasKey("Id");
            }
        }
        base.OnModelCreating(modelBuilder);
    }
}