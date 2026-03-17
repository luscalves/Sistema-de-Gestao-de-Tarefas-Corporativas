namespace SistemaDeGestaoDeTarefas.Application.DTOs
{
    public class TarefaResponseDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public int? UsuarioAtribuidoId { get; set; }
        public string? MotivoBloqueio { get; set; }
    }
}
