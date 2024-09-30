using TarefaAPI.Domain;
using TarefaAPI.Repository;
using TarefaAPI.Repository.Interfaces;


namespace TarefaAPI.Infra.Data;

public class UnityOfWork : IUnityOfWork
{
    private readonly ApiDbContext _context;

    public UnityOfWork(ApiDbContext context)
    {
        _context = context;
        Tarefas = new TarefaRepository(_context, _context.Set<Tarefa>()); 
    }

    public ITarefaRepository Tarefas { get; private set; }

    public async Task CompletAsync()
    {
        await _context.SaveChangesAsync(); 
    }

   
}