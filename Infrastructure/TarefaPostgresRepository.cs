using SistemaDeGestaoDeTarefas;
using SistemaDeGestaoDeTarefas.Entities;


namespace SistemaDeGestaoDeTarefas.Infrastructure
{
    public class TarefaPostgresRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaPostgresRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Adicionar(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }

        public Tarefa? ObterPorId(int id)
        {
            return _context.Tarefas.FirstOrDefault(t => t.Id == id);
        }

        public void Atualizar(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();
        }

        public void Remover(Tarefa tarefa)
        {
            // O Entity Framework apenas marca a entidade para exclusão
            _context.Tarefas.Remove(tarefa);
    
            // O SaveChanges vai no banco e executa o DELETE de fato
            _context.SaveChanges();
        }
        
        public IEnumerable<Tarefa> ObterTodas()
        {
            // O Entity Framework vai no banco, faz um SELECT * FROM Tarefas e transforma em uma lista
            return _context.Tarefas.ToList();
        }
    }
}

