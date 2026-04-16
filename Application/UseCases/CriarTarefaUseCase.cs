using System;
using SistemaDeGestaoDeTarefas.Domain.Entities;
using SistemaDeGestaoDeTarefas;

namespace SistemaDeGestaoDeTarefas.Application.UseCases;

public class CriarTarefaUseCase
{
    private readonly ITarefaRepository _tarefaRepository;

    public CriarTarefaUseCase(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    public Tarefa Executar(string titulo, string descricao)
    {
        var novaTarefa = new Tarefa(titulo, descricao);
        
        _tarefaRepository.Adicionar(novaTarefa);
        
        return novaTarefa;
    }
}