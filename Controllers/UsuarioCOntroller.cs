using Microsoft.AspNetCore.Mvc;
using SistemaDeGestaoDeTarefas.Domain.Entities;
using SistemaDeGestaoDeTarefas.Infrastructure;

namespace SistemaDeGestaoDeTarefas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuarioController(AppDbContext context)
    {
        _context = context;
    }

    // Rota para o Front-end listar quem pode assumir a tarefa
    [HttpGet]
    public IActionResult ListarUsuarios()
    {
        var usuarios = _context.Usuarios.ToList();
        return Ok(usuarios);
    }

    // Rota rápida para criarmos nossos usuários de teste
    public class CriarUsuarioRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Usuario.TipoDepartamento Departamento { get; set; }
    }

    [HttpPost]
    public IActionResult CriarUsuario([FromBody] CriarUsuarioRequest request)
    {
        var novoUsuario = new Usuario(request.Nome, request.Email, request.Departamento);
        
        _context.Usuarios.Add(novoUsuario);
        _context.SaveChanges();

        return Created($"/api/usuario/{novoUsuario.Id}", novoUsuario);
    }
}