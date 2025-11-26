using Microsoft.EntityFrameworkCore;
using ShopSystem.infrastructure.AppDbContext;

namespace ShopSystem.infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ShopSystemDbContext _context;
    private readonly DbSet<T> _db;

    public Repository(ShopSystemDbContext context)
    {
        _context = context;
        _db = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(params object[] ids)
    {
        return await _db.FindAsync(ids);
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

    public void Delete(T entity)
    {
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
