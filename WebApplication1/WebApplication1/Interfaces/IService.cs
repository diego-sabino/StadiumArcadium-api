namespace WebApplication1.Interfaces;

public interface IService<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(string id);
    Task CreateAsync(T entity);
    Task UpdateAsync(string id, T entity);
    Task RemoveAsync(string id);
}