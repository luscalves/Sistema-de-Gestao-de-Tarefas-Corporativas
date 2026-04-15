using System;
namespace SistemaDeGestaoDeTarefas.UseCases;

public class ExcluirTarefaUseCase
{
    private readonly ITarefaRepository _tarefaRepository;
    public ExcluirTarefaUseCase(ITarefaRepository tarefaRepository) => _tarefaRepository = tarefaRepository;

    public void Executar(int id)
    {
        var tarefa = _tarefaRepository.ObterPorId(id);
        if (tarefa == null) throw new Exception("Tarefa não encontrada.");

        _tarefaRepository.Remover(tarefa);
    }
}