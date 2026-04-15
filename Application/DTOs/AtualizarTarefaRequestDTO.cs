namespace SistemaDeGestaoDeTarefas.Application.DTOs;

public class AtualizarTarefaRequestDTO
{
    public required string Titulo { get; set; }
    public required string Descricao { get; set; }
}