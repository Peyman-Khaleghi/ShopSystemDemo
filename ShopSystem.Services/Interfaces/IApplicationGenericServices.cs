using ShopSystem.Domain.Models;

namespace ShopSystem.Services;

public interface IApplicationGenericServices<TEntity, TId, TItem, TOutput, TInput,TUpdate>
    where TEntity : class, IBaseEntity<TId>
{
    Task<TOutput> GetByIdAsync(TId id);
    Task<IEnumerable<TItem>> GetAllAsync();
    Task<TId> AddAsync(TInput input);
    Task UpdateAsync(TId id, TUpdate update);
    Task DeleteAsync(TId id);
}