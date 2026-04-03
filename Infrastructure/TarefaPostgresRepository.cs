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

        public Tarefa? BuscarPorId(int id)
        {
            return _context.Tarefas.FirstOrDefault(t => t.Id == id);
        }

        public void Atualizar(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                _context.SaveChanges();
            }
        }
    }
}

