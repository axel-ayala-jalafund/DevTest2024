using ApiBackend.Core.src.Domain.Entity;
using ApiBackend.Core.src.Domain.Interfaces.Repositories;
using ApiBackend.Infraestructure.src.Data.Memory;

namespace ApiBackend.Infraestructure.src.Repositories.BaseMemoryRepository;

public abstract class BaseMemoryRepository<T> : IRepository<T> where T : class, IEntity
{
    protected readonly MemoryContext _context;
    protected abstract List<T> GetDbSet();

    public BaseMemoryRepository(MemoryContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(T item)
    {
        if (item.Id == Guid.Empty)
        {
            item.Id = Guid.NewGuid();
        }

        GetDbSet().Add(item);
        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var item = await GetByIdAsync(id);
        if (item == null)
        {
            return await Task.FromResult(false);
        }

        GetDbSet().Remove(item);
        return await Task.FromResult(true);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Task.FromResult(GetDbSet());
    }

    public Task<T?> GetByIdAsync(Guid id)
    {
        var item = GetDbSet().FirstOrDefault(x => x.Id == id);
        return Task.FromResult(item);
    }
}
