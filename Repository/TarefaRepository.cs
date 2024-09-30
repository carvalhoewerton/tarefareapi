using Microsoft.EntityFrameworkCore;
using TarefaAPI.Domain;
using TarefaAPI.Domain.Enums;
using TarefaAPI.Infra.Data;
using TarefaAPI.Repository.Interfaces;

namespace TarefaAPI.Repository;

public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
{
    public TarefaRepository(ApiDbContext apiDbContext, DbSet<Tarefa> dbSet) : base(apiDbContext, dbSet)
    {
    }

    public virtual async Task<IEnumerable<Tarefa>> GetAllTarefasAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public virtual async Task <IEnumerable<Tarefa>> All()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public virtual async Task<Tarefa> FindById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> Add(Tarefa entity)
    {
        _dbSet.Add(entity);
        return true;
    }

    public virtual async Task<bool> Update(Tarefa entity)
    {
        _dbSet.Update(entity);
        return true;
    }

    public virtual async Task<bool> Remove(Tarefa entity)
    {
        _dbSet.Remove(entity);
        return true;
    }

    public async Task<IEnumerable<Tarefa>> FindByTitulo(string titulo)
    {
        return await _dbSet.Where(t => t.Titulo == titulo).ToListAsync();
    }

    public async Task<IEnumerable<Tarefa>> FindByData(string data)
    {
        DateTime date = DateTime.Parse(data);
        return await _dbSet.Where(t => t.Data == date).ToListAsync();
    }

    public async Task<IEnumerable<Tarefa>> FindByStatus(bool doneOrNot)
    {
        if (doneOrNot)
        {
            return await _dbSet.Where(t => t.Status == Status.Done).ToListAsync();
        }
        return await _dbSet.Where(t => t.Status == Status.Todo).ToListAsync();
        
    }

    
}
