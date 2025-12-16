using ShopSystem.Domain.Models;
using ShopSystem.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ShopSystemDbContext _context;
    private Dictionary<Type, object> _repositories;

    public UnitOfWork(ShopSystemDbContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }

    public IRepository<T, TId> GetRepository<T, TId>()
        where T : class, IBaseEntity<TId>
    {
        var type = typeof(T);

        if (_repositories.ContainsKey(type))
        {
            return (IRepository<T, TId>)_repositories[type];
        }

        var repositoryInstance = new Repository<T, TId>(_context);
        _repositories.Add(type, repositoryInstance);

        return repositoryInstance;
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }
}