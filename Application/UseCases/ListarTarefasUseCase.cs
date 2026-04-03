using SistemaDeGestaoDeTarefas;
using SistemaDeGestaoDeTarefas.Application.DTOs;

public class ListarTarefasUseCase
{
    private readonly ITarefaRepository _tarefaRepository;

    public ListarTarefasUseCase(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }
    public IEnumerable<TarefaResponseDTO> Executar()
    {
        var tarefas = _tarefaRepository.ObterTodas();

        return tarefas.Select(t => new TarefaResponseDTO
        {
            Id = t.Id,
            Titulo = t.Titulo,
            Descricao = t.Descricao,
            Status = t.Status.ToString(), // Converte o Enum para String
            DataCriacao = t.DataCriacao,
            UsuarioAtribuidoId = t.UsuarioAtribuidoId,
            MotivoBloqueio = t.MotivoBloqueio
        });
    }
}