using Microsoft.EntityFrameworkCore;
using TarefaAPI.Domain;

namespace TarefaAPI.Infra.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("ConexaoPadrao");
        }
    }
    public DbSet<Tarefa> Tarefas { get; set; }
}