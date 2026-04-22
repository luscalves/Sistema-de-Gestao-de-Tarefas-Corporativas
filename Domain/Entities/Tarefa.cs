namespace SistemaDeGestaoDeTarefas.Domain.Entities
{
    public class Tarefa
    {
        public int Id{get; private set;}
        public int? UsuarioAtribuidoId{get; private set;}
        
        public Usuario? UsuarioAtribuido { get; private set; }
        public string Titulo{get; private set;}
        public string Descricao{get; private set;}
        public StatusTarefa Status{get; private set;}
        public DateTime DataCriacao{get; private set;}
        public string? MotivoBloqueio{get; private set;}

        public enum StatusTarefa
        {
            Pendente,
            EmAndamento,
            Concluida,
            Bloqueada
        }

        public Tarefa(string titulo, string descricao)
        {
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Status = StatusTarefa.Pendente;
            this.DataCriacao = DateTime.UtcNow;
        }

        public void Concluir(){
           if(this.UsuarioAtribuidoId == null){
            throw new Exception("Ação inválida: Tarefa concluída sem usuário atribuído.");
           } else{
            this.Status = StatusTarefa.Concluida;
           }
        }

        public void Bloquear(string MotivoBloqueio){
            if(string.IsNullOrEmpty(MotivoBloqueio)){
                throw new Exception("Ação inválida: tarefa bloqueada sem motivo atribuído.");
            } else {
                this.Status = StatusTarefa.Bloqueada;
                this.MotivoBloqueio = MotivoBloqueio;
            }
        }

        public void AtribuirUsuario(Usuario usuario){
            if(this.UsuarioAtribuidoId != null){
                throw new Exception("Ação inválida: tarefa já atribuida para um usuário");
            } else{
                this.UsuarioAtribuidoId = usuario.Id;
                this.UsuarioAtribuido = usuario;
                this.Status = StatusTarefa.EmAndamento;
            }
        }
        public void AtualizarDetalhes(string novoTitulo, string novaDescricao)
        {
            // Aqui você poderia até colocar validações futuras, ex:
            // if (string.IsNullOrWhiteSpace(novoTitulo)) throw new Exception(...);

            Titulo = novoTitulo;
            Descricao = novaDescricao;
        }
        public void Desatribuir()
        {
            // Remove o dono
            this.UsuarioAtribuidoId = null;
        
            // Joga a tarefa de volta para a primeira coluna
            this.Status = StatusTarefa.Pendente; 
        }
    }
}
