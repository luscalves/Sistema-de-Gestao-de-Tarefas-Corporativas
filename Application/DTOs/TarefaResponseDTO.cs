using SistemaDeGestaoDeTarefas.Domain.Entities;

namespace SistemaDeGestaoDeTarefas.Application.DTOs
{
    public class TarefaResponseDTO
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string Descricao { get; set; }
        public required string Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public int? UsuarioAtribuidoId { get; set; }
        public string? MotivoBloqueio { get; set; }
    }
}
