using SistemaDeGestaoDeTarefas.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeGestaoDeTarefas.Application.UseCases;

public class ListarUsuariosUseCase
{
    private readonly IUsuarioRepository _repository;

    public ListarUsuariosUseCase(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<object> Executar()
    {
        var todosUsuarios = _repository.ListarTodos();

        return todosUsuarios
            .Where(u => u.Ativo)
            .Select(u => new 
            {
                id = u.Id,
                nome = u.Nome,
                email = u.Email,
                departamento = u.Departamento.ToString()
            });
    }
}
