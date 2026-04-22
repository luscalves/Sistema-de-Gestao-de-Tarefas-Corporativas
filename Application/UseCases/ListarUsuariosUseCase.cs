using SistemaDeGestaoDeTarefas.Infrastructure;

namespace SistemaDeGestaoDeTarefas.Application.UseCases;

public class ListarUsuariosUseCase
{
    private readonly AppDbContext _context;

    public ListarUsuariosUseCase(AppDbContext context)
    {
        _context = context;
    }

    // Usamos 'object' aqui para simplificar, mas num cenário 100% purista, 
    // retornaríamos uma List<UsuarioResponseDTO>
    public object Executar()
    {
        return _context.Usuarios
            .Select(u => new 
            {
                u.Id,
                u.Nome,
                u.Email,
                u.Departamento
            })
            .ToList();
    }
}