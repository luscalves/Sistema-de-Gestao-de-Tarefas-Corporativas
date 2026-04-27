using Microsoft.AspNetCore.Mvc;
using SistemaDeGestaoDeTarefas.Application.UseCases;

namespace SistemaDeGestaoDeTarefas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request, [FromServices] FazerLoginUseCase useCase)
    {
        try
        {
            var resultado = useCase.Executar(request.Email, request.Senha);
            return Ok(resultado); // Devolve status 200 com o Token e dados do usuário
        }
        catch (Exception ex)
        {
            return Unauthorized(new { erro = ex.Message }); // Status 401: Não autorizado
        }
    }
}