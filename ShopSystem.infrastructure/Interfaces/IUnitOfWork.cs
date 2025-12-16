using ShopSystem.Domain.Models;

namespace ShopSystem.Infrastructure;

public interface IUnitOfWork
{
    IRepository<T, TId> GetRepository<T, TId>() where T : class, IBaseEntity<TId>;

    Task<int> CompleteAsync();
}
