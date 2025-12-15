using Microsoft.EntityFrameworkCore;
using ShopSystem.Domain.Models;

namespace ShopSystem.Infrastructure;

public class Repository<T,TId> : IRepository<T,TId> where T : class , IBaseEntity<TId>
{
    private readonly ShopSystemDbContext _context;
    private readonly DbSet<T> _db;

    public Repository(ShopSystemDbContext context)
    {
        _context = context;
        _db = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(TId id)
    {
        return await _db.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _db.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _db.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _db.Update(entity);
    }

    public async Task Delete(TId id)
    {
        var entity =await GetByIdAsync(id);
        _db.Remove(entity);
    }

    public IQueryable<T> Query()
    {
        return _db.AsQueryable();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
