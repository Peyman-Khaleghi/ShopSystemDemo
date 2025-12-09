using ShopSystem.Domain.Models;

namespace ShopSystem.Domain.Interfaces;

public interface IRepository<T,TId> where T : class , IBaseEntity<TId>
{
    Task<T> GetByIdAsync(TId id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    Task Delete(TId id);
    IQueryable<T> Query();
    Task<int> SaveChangesAsync();
}