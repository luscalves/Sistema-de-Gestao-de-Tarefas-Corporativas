namespace SistemaDeGestaoDeTarefas.Application.DTOs;

public class CriarTarefaRequestDTO
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
}