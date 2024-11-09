using ApiBackend.Core.src.Domain.Entity;

namespace ApiBackend.Core.src.Domain.Interfaces.Repositories;

public interface IRepository <T> where T : IEntity
{
    Task<bool> CreateAsync(T item);
    Task<bool> DeleteAsync(Guid id);
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
}
