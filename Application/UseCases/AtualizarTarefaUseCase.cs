using System;
namespace SistemaDeGestaoDeTarefas.UseCases;

public class AtualizarTarefaUseCase
{
    private readonly ITarefaRepository _tarefaRepository;
    public AtualizarTarefaUseCase(ITarefaRepository tarefaRepository) => _tarefaRepository = tarefaRepository;

    public void Executar(int id, string novoTitulo, string novaDescricao)
    {
        var tarefa = _tarefaRepository.ObterPorId(id);
        if (tarefa == null) throw new Exception("Tarefa não encontrada.");

        tarefa.AtualizarDetalhes(novoTitulo, novaDescricao);
        _tarefaRepository.Atualizar(tarefa);
    }
}