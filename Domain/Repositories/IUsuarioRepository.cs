using SistemaDeGestaoDeTarefas.Domain.Entities;

namespace SistemaDeGestaoDeTarefas;

public interface IUsuarioRepository
{
    Usuario ObterPorId(int id);
}