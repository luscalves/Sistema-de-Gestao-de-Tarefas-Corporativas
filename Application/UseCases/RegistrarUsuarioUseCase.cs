using SistemaDeGestaoDeTarefas.Domain.Entities;
using BCrypt.Net;

namespace SistemaDeGestaoDeTarefas.Application.UseCases;

public class RegistrarUsuarioUseCase
{
    private readonly IUsuarioRepository _repository;

    public RegistrarUsuarioUseCase(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public void Executar(string nome, string email, string senhaAberta, Usuario.TipoDepartamento departamento)
    {
        if (_repository.ExisteEmail(email))
            throw new Exception("Este e-mail já está em uso por outro usuário.");

        string hashDaSenha = BCrypt.Net.BCrypt.HashPassword(senhaAberta);

        var novoUsuario = new Usuario(nome, email, hashDaSenha, departamento);

        _repository.Adicionar(novoUsuario);
    }
}
