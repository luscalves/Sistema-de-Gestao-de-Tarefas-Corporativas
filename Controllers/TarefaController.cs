using Microsoft.AspNetCore.Mvc;
using SistemaDeGestaoDeTarefas.Application.DTOs;
using SistemaDeGestaoDeTarefas.Application.UseCases;
using SistemaDeGestaoDeTarefas.UseCases;

namespace SistemaDeGestaoDeTarefas.Controllers;

[ApiController] 
[Route("api/[controller]")] 
public class TarefaController : ControllerBase
{
    private readonly ConcluirTarefaUseCase _concluirTarefaUseCase;
    private readonly CriarTarefaUseCase _criarTarefaUseCase;
    private readonly ListarTarefasUseCase _listarTarefasUseCase; // 1. Declarado aqui
    
    // 2. Injetado no construtor
    public TarefaController(
        ConcluirTarefaUseCase concluirTarefaUseCase, 
        CriarTarefaUseCase criarTarefaUseCase,
        ListarTarefasUseCase listarTarefasUseCase) 
    {
        _concluirTarefaUseCase = concluirTarefaUseCase;
        _criarTarefaUseCase = criarTarefaUseCase;
        _listarTarefasUseCase = listarTarefasUseCase;
    }

    [HttpPost]
    public IActionResult Criar([FromBody] CriarTarefaRequestDTO request)
    {
        var novaTarefa = _criarTarefaUseCase.Executar(request.Titulo, request.Descricao);
        return Created("", novaTarefa);
    }

    [HttpGet]
    public IActionResult ListarTodas() // 3. Removido o [FromServices] daqui
    {
        var tarefas = _listarTarefasUseCase.Executar(); // 4. Usando a variável global
        return Ok(tarefas);
    }
    
    [HttpPut("{id}/concluir")]
    public IActionResult Concluir(int id)
    {
        try
        {
            var resultado = _concluirTarefaUseCase.Executar(id);
            return Ok(resultado); 
        }
        catch (System.Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
}