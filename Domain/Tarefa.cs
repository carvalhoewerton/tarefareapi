using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TarefaAPI.Domain.Enums;

namespace TarefaAPI.Domain;

public class Tarefa
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public Status Status { get; set; }  
    
}