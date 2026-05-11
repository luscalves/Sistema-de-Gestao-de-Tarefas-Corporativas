using SistemaDeGestaoDeTarefas.Infrastructure;

namespace SistemaDeGestaoDeTarefas.Application.UseCases;

public class BloquearTarefaUseCase
{
    private readonly AppDbContext _context;

    public BloquearTarefaUseCase(AppDbContext context)
    {
        _context = context;
    }

    public void Executar(int id, string motivo)
    {
        var tarefa = _context.Tarefas.Find(id);
        if (tarefa == null) throw new Exception("Tarefa não encontrada.");

        tarefa.Bloquear(motivo); 

        _context.SaveChanges();
    }
}
