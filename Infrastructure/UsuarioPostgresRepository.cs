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
}