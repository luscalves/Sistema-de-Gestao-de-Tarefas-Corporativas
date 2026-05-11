using SistemaDeGestaoDeTarefas.Domain.Entities;
using System.Collections.Generic;

namespace SistemaDeGestaoDeTarefas;

public interface IUsuarioRepository
{
    Usuario ObterPorId(int id);
    bool ExisteEmail(string email);
    Usuario ObterPorEmail(string email);
    void Adicionar(Usuario usuario);
    
    IEnumerable<Usuario> ListarTodos();
}
