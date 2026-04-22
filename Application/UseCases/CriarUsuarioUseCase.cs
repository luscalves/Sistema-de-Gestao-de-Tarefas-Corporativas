using SistemaDeGestaoDeTarefas.Domain.Entities;

namespace SistemaDeGestaoDeTarefas.Application.UseCases;

public class CriarUsuarioUseCase
{
    private readonly IUsuarioRepository _repository;

    public CriarUsuarioUseCase(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    // Adicionamos a 'senha' como parâmetro aqui
    public void Executar(string nome, string email, string senha, Usuario.TipoDepartamento departamento)
    {
        if (_repository.ExisteEmail(email))
            throw new Exception("Este e-mail já está cadastrado.");

        // 1. Gerar o Hash da senha antes de criar o objeto
        string senhaHash = BCrypt.Net.BCrypt.HashPassword(senha);

        // 2. Agora passamos os 4 argumentos exigidos pelo construtor
        var novoUsuario = new Usuario(nome, email, senhaHash, departamento);

        _repository.Adicionar(novoUsuario);
    }
}