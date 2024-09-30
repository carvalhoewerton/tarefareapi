namespace TarefaAPI.Repository.Interfaces;

public interface IUnityOfWork
{
    ITarefaRepository Tarefas { get; }
    Task CompletAsync();
}