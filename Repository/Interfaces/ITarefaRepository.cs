using Microsoft.EntityFrameworkCore;
using TarefaAPI.Domain;
using TarefaAPI.Infra.Data;

namespace TarefaAPI.Repository.Interfaces;

public interface ITarefaRepository : IBaseRepository<Tarefa>
{
   Task<IEnumerable<Tarefa>> FindByTitulo(string titulo);
   Task<IEnumerable<Tarefa>> FindByData(string titulo);
   Task<IEnumerable<Tarefa>> FindByStatus(bool doneOrNot);
}