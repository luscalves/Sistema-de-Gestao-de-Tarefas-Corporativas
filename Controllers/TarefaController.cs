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
    private readonly ListarTarefasUseCase _listarTarefasUseCase;
    
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
    public IActionResult ListarTodas() 
    {
        var tarefas = _listarTarefasUseCase.Executar(); 
        return Ok(tarefas);
    }
    
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
            return NoContent(); 
        }
        catch (Exception ex)
        {
            return NotFound(new { erro = ex.Message });
        }
    }

    [HttpPut("{id}/concluir")]
    public IActionResult Concluir(int id)
    {
        try
        {
            var resultado = _concluirTarefaUseCase.Executar(id);
            return Ok(resultado); 
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    // Contrato para receber o JSON do React
    public class AtribuirUsuarioRequest
    {
        public int UsuarioId { get; set; }
    }

    [HttpPut("{id}/atribuir")]
    public IActionResult Atribuir(int id, [FromBody] AtribuirUsuarioRequest request, [FromServices] AtribuirUsuarioUseCase _useCase)
    {
        try
        {
            _useCase.Executar(id, request.UsuarioId);
            return Ok(new { mensagem = "Usuário atribuído à tarefa com sucesso!" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    // Apenas UM método de Deletar para evitar conflito de rotas
    [HttpDelete("{id}")]
    public IActionResult Deletar(int id, [FromServices] DeletarTarefaUseCase _useCase)
    {
        try
        {
            _useCase.Executar(id);
            return Ok(new { mensagem = "Tarefa excluída com sucesso!" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
    public class BloquearTarefaRequest
    {
        public string Motivo { get; set; }
    }

    [HttpPut("{id}/bloquear")]
    public IActionResult Bloquear(int id, [FromBody] BloquearTarefaRequest request, [FromServices] BloquearTarefaUseCase _useCase)
    {
        try
        {
            _useCase.Executar(id, request.Motivo);
            return Ok(new { mensagem = "Tarefa bloqueada com sucesso!" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
}