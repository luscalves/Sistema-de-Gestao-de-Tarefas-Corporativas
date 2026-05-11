using SistemaDeGestaoDeTarefas.Infrastructure;
using System.Linq;

namespace SistemaDeGestaoDeTarefas.Application.UseCases;

public class DesativarUsuarioUseCase
{
    private readonly AppDbContext _context;

    public DesativarUsuarioUseCase(AppDbContext context)
    {
        _context = context;
    }

    public void Executar(int usuarioId)
    {

        var usuario = _context.Usuarios.Find(usuarioId);
        if (usuario == null) throw new Exception("Usuário não encontrado.");

        usuario.Desativar();

        var tarefasDoUsuario = _context.Tarefas
            .Where(t => t.UsuarioAtribuidoId == usuarioId && t.Status != Domain.Entities.Tarefa.StatusTarefa.Concluida)
            .ToList();

        foreach (var tarefa in tarefasDoUsuario)
        {
            tarefa.Desatribuir(); 
        }
        _context.SaveChanges();
    }
}
