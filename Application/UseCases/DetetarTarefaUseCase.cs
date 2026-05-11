using SistemaDeGestaoDeTarefas.Infrastructure;

namespace SistemaDeGestaoDeTarefas.Application.UseCases;

public class DeletarTarefaUseCase
{
    private readonly AppDbContext _context;

    public DeletarTarefaUseCase(AppDbContext context)
    {
        _context = context;
    }

    public void Executar(int id)
    {
        var tarefa = _context.Tarefas.Find(id);

        if (tarefa == null) 
            throw new Exception("Tarefa não encontrada para exclusão.");

        _context.Tarefas.Remove(tarefa);
        _context.SaveChanges();
    }
}
