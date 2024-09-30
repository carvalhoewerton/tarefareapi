
using Microsoft.EntityFrameworkCore;
using TarefaAPI.Domain;
using TarefaAPI.Infra.Data;
using TarefaAPI.Repository.Interfaces;

namespace TarefaAPI.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T: class
{
    
    private readonly ApiDbContext _apiDbContext;
    internal Microsoft.EntityFrameworkCore.DbSet<T> _dbSet;


    public BaseRepository(ApiDbContext apiDbContext, DbSet<T> dbSet)
    {
        _apiDbContext = apiDbContext;
        _dbSet = dbSet;
    }
    


    public virtual async Task<IEnumerable<T>> All()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T> FindById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    public virtual async Task<bool> Update(T entity)
    {
        _dbSet.Update(entity);
        return true;
    }
    
    public virtual async Task<bool> Remove(T entity)
    {
        _dbSet.Remove(entity);
        return true;
    }
}