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
    // Adicione as rotas abaixo das que você já tem (Criar, ListarTodas, Concluir)

    [HttpGet("{id}")]
    public IActionResult ObterPorId(int id, [FromServices] ObterTarefaPorIdUseCase useCase)
    {
        var tarefa = useCase.Executar(id);
        if (tarefa == null) return NotFound(new { mensagem = "Tarefa não encontrada" });
    
        return Ok(tarefa);
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, [FromBody] AtualizarTarefaRequestDTO request, [FromServices] AtualizarTarefaUseCase useCase)
    {
        try
        {
            useCase.Executar(id, request.Titulo, request.Descricao);
            return NoContent(); // 204 No Content é o padrão para atualizações bem-sucedidas
        }
        catch (Exception ex)
        {
            return NotFound(new { erro = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Excluir(int id, [FromServices] ExcluirTarefaUseCase useCase)
    {
        try
        {
            useCase.Executar(id);
            return NoContent(); // 204 No Content para deleções bem-sucedidas
        }
        catch (Exception ex)
        {
            return NotFound(new { erro = ex.Message });
        }
    }
}