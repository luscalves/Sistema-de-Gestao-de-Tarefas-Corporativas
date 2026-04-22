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
        // 1. Procura a tarefa no banco
        var tarefa = _context.Tarefas.Find(id);
        
        // 2. Se não achar, lança um erro
        if (tarefa == null) 
            throw new Exception("Tarefa não encontrada para exclusão.");

        // 3. Remove do Entity Framework e salva
        _context.Tarefas.Remove(tarefa);
        _context.SaveChanges();
    }
}