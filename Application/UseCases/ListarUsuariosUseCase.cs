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
        // Pega todos os usuários do banco
        var todosUsuarios = _repository.ListarTodos();

        // Filtra apenas os ATIVOS e cria um objeto limpo (sem a senha) para o React
        return todosUsuarios
            .Where(u => u.Ativo)
            .Select(u => new 
            {
                id = u.Id,
                nome = u.Nome,
                email = u.Email,
                departamento = u.Departamento.ToString() // Envia o nome do departamento em vez do número
            });
    }
}