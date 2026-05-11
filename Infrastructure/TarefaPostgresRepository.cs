using SistemaDeGestaoDeTarefas;
using SistemaDeGestaoDeTarefas.Domain.Entities;



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
            _context.Tarefas.Remove(tarefa);
    
            _context.SaveChanges();
        }
        
        public IEnumerable<Tarefa> ObterTodas()
        {
            return _context.Tarefas.ToList();
        }
    }
}

