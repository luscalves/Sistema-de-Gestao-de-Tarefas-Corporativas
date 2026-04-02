using SistemaDeGestaoDeTarefas;
using SistemaTarefasCorporativas.Entities;

namespace SistemaTarefasCorporativas.Infrastructure
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
            throw new NotImplementedException();
        }

        public Tarefa? BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}

