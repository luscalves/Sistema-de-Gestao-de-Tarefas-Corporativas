using SistemaDeGestaoDeTarefas;
using SistemaDeGestaoDeTarefas.Domain.Entities;

namespace SistemaDeGestaoDeTarefas.Infrastructure;

public class UsuarioPostgresRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioPostgresRepository(AppDbContext context)
    {
        _context = context;
    }

    public Usuario? ObterPorId(int id)
    {
        // O Entity Framework vai no banco fazer um "SELECT * FROM Usuarios WHERE Id = {id}"
        return _context.Usuarios.Find(id); 
    }
    // Adicione estes métodos dentro da sua classe UsuarioPostgresRepository
    public bool ExisteEmail(string email)
    {
        return _context.Usuarios.Any(u => u.Email == email);
    }

    public Usuario ObterPorEmail(string email)
    {
        return _context.Usuarios.FirstOrDefault(u => u.Email == email);
    }

    public void Adicionar(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }
}