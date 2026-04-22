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
        // 1. Busca o usuário
        var usuario = _context.Usuarios.Find(usuarioId);
        if (usuario == null) throw new Exception("Usuário não encontrado.");

        // 2. Aplica a regra de negócio do usuário (DDD)
        usuario.Desativar();

        // 3. Busca todas as tarefas que estão com este usuário E que não estão concluídas
        // (Afinal, se a tarefa já foi concluída, ela pode ficar no histórico dele)
        var tarefasDoUsuario = _context.Tarefas
            .Where(t => t.UsuarioAtribuidoId == usuarioId && t.Status != Domain.Entities.Tarefa.StatusTarefa.Concluida)
            .ToList();

        // 4. Para cada tarefa encontrada, nós a desatribuímos
        foreach (var tarefa in tarefasDoUsuario)
        {
            tarefa.Desatribuir(); // A entidade Tarefa aplica a própria regra!
        }

        // 5. O GRANDE FINAL: Salva tudo de uma vez (Transação Atômica)
        _context.SaveChanges();
    }
}