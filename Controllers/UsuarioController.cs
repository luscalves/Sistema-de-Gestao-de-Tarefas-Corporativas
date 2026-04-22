using Microsoft.AspNetCore.Mvc;
using SistemaDeGestaoDeTarefas.Domain.Entities;
using SistemaDeGestaoDeTarefas.Application.UseCases; // Assumindo que os UseCases ficarão aqui

namespace SistemaDeGestaoDeTarefas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    // O DTO (Objeto de Transferência) que recebe os dados do React
    public class CriarUsuarioRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Usuario.TipoDepartamento Departamento { get; set; }
    }

    [HttpGet]
    public IActionResult ListarTodos([FromServices] ListarUsuariosUseCase _useCase)
    {
        try
        {
            // O Controller não faz ideia de como a lista é gerada, ele só pede a lista.
            var usuarios = _useCase.Executar();
            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = "Não foi possível listar os usuários.", detalhe = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult CriarUsuario([FromBody] CriarUsuarioRequest request, [FromServices] CriarUsuarioUseCase _useCase)
    {
        try
        {
            // O Controller manda os dados para a regra de negócio
            var novoUsuario = _useCase.Executar(request.Nome, request.Email, request.Departamento);
            
            return Created($"/api/usuario/{novoUsuario.Id}", novoUsuario);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
}