namespace ShopSystem.infrastructure.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(params object[] ids);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    IQueryable<T> Query();
    Task<int> SaveChangesAsync();
}