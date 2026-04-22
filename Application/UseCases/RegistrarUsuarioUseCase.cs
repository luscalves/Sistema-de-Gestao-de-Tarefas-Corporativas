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
        // 1. Verifica se o e-mail já existe
        if (_repository.ExisteEmail(email))
            throw new Exception("Este e-mail já está em uso por outro usuário.");

        // 2. A MÁGICA DA SEGURANÇA: Criptografa a senha usando BCrypt
        string hashDaSenha = BCrypt.Net.BCrypt.HashPassword(senhaAberta);

        // 3. Cria a entidade com a senha protegida
        var novoUsuario = new Usuario(nome, email, hashDaSenha, departamento);

        // 4. Salva no banco de dados
        _repository.Adicionar(novoUsuario);
    }
}