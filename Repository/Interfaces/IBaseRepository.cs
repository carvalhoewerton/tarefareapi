namespace TarefaAPI.Repository.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> All();
    Task<T> FindById(int id);
    Task<bool> Add(T entity);
    Task<bool> Update(T entity);
    Task<bool> Remove(T entity);
}