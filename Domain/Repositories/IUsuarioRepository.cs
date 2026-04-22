using SistemaDeGestaoDeTarefas.Domain.Entities;
using System.Collections.Generic;

namespace SistemaDeGestaoDeTarefas;

public interface IUsuarioRepository
{
    // O que já tínhamos
    Usuario ObterPorId(int id);
    
    // Novos poderes para atender o Front-end
   
    // IEnumerable<Usuario> ListarTodos();
    
    // Regra de negócio crucial: Evitar e-mails duplicados
    bool ExisteEmail(string email);
    Usuario ObterPorEmail(string email);
    void Adicionar(Usuario usuario);
}