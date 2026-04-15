using SistemaDeGestaoDeTarefas.Application.DTOs;
namespace SistemaDeGestaoDeTarefas.UseCases;

public class ObterTarefaPorIdUseCase
{
    private readonly ITarefaRepository _tarefaRepository;
    public ObterTarefaPorIdUseCase(ITarefaRepository tarefaRepository) => _tarefaRepository = tarefaRepository;

    public TarefaResponseDTO? Executar(int id)
    {
        var tarefa = _tarefaRepository.ObterPorId(id);
        if (tarefa == null) return null;

        return new TarefaResponseDTO
        {
            Id = tarefa.Id,
            Titulo = tarefa.Titulo,
            Descricao = tarefa.Descricao,
            Status = tarefa.Status.ToString(),
            DataCriacao = tarefa.DataCriacao,
            UsuarioAtribuidoId = tarefa.UsuarioAtribuidoId,
            MotivoBloqueio = tarefa.MotivoBloqueio
        };
    }
}