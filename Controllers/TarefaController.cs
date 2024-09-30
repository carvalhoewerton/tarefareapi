using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TarefaAPI.Domain;
using TarefaAPI.Infra.Data;
using TarefaAPI.Repository.Interfaces;

namespace TarefaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TarefaController : ControllerBase
{
    private readonly IUnityOfWork _unityOfWork;


    public TarefaController(IUnityOfWork unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _unityOfWork.Tarefas.All());
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Tarefa tarefa)
    {
        await _unityOfWork.Tarefas.Add(tarefa);
        await _unityOfWork.CompletAsync();
        return CreatedAtAction(nameof(Get), new { id = tarefa.Id }, tarefa);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var tarefa = await _unityOfWork.Tarefas.FindById(id);
        await _unityOfWork.CompletAsync();
        return CreatedAtAction(nameof(Get), new { id = tarefa.Id }, tarefa);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, [FromBody] Tarefa tarefaAtualizada)
    {
        if (tarefaAtualizada == null)
        {
            return BadRequest("Os dados da tarefa não podem ser nulos.");
        }

        var tarefaExistente = await _unityOfWork.Tarefas.FindById(id);
    
        if (tarefaExistente == null)
        {
            return NotFound(); 
        }
        tarefaExistente.Data = tarefaAtualizada.Data;
        tarefaExistente.Descricao = tarefaAtualizada.Descricao;
        tarefaExistente.Status = tarefaAtualizada.Status;
        tarefaExistente.Titulo = tarefaAtualizada.Titulo;
        await _unityOfWork.CompletAsync(); 
        return Ok(tarefaExistente); 
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(int id)
    {
        var tarefa = await _unityOfWork.Tarefas.FindById(id);
        if (tarefa == null)
        {
            return NotFound();
        }
        await _unityOfWork.CompletAsync();
        return Ok();
    }
    
    [HttpGet("/status/{byStatus}")]
    public async Task<IActionResult> GetByStatus(int byStatus)
    {
        if (byStatus == 2)
        {
            return Ok(await _unityOfWork.Tarefas.FindByStatus(true));
        }
        return Ok(await _unityOfWork.Tarefas.FindByStatus(false));
    }

    [HttpGet("/data/{data}")]
    public async Task<IActionResult> GetByData(string data)
    {
        return Ok(await _unityOfWork.Tarefas.FindByData(data));
    }

    [HttpGet("/titulo/{titulo}")]
    public async Task<IActionResult> GetByTitulo(string titulo)
    {
        return Ok(await _unityOfWork.Tarefas.FindByTitulo(titulo));
    }
}