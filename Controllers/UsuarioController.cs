using Microsoft.AspNetCore.Mvc;
using SistemaDeGestaoDeTarefas.Application.UseCases;

namespace SistemaDeGestaoDeTarefas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    [HttpPut("{id}/desativar")]
    public IActionResult Desativar(int id, [FromServices] DesativarUsuarioUseCase useCase)
    {
        try
        {
            useCase.Executar(id);
            return Ok(new { mensagem = "Usuário desativado e tarefas devolvidas para o painel com sucesso!" });
        }
        catch (System.Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
    public class CriarUsuarioRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Departamento { get; set; } 
    }

    [HttpPost]
    public IActionResult Criar([FromBody] CriarUsuarioRequest request, [FromServices] CriarUsuarioUseCase useCase)
    {
        try
        {
            useCase.Executar(
                request.Nome, 
                request.Email, 
                request.Senha, 
                (Domain.Entities.Usuario.TipoDepartamento)request.Departamento
            );
            
            return Created("", new { mensagem = "Usuário criado com sucesso!" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
    
    [HttpGet]
    public IActionResult ListarTodos([FromServices] ListarUsuariosUseCase useCase)
    {
        try
        {
            var usuarios = useCase.Executar();
            return Ok(usuarios);
        }
        catch (System.Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
}
