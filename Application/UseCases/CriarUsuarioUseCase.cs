using SistemaDeGestaoDeTarefas.Domain.Entities;
using SistemaDeGestaoDeTarefas.Infrastructure;

namespace SistemaDeGestaoDeTarefas.Application.UseCases;

public class CriarUsuarioUseCase
{
    private readonly AppDbContext _context;

    public CriarUsuarioUseCase(AppDbContext context)
    {
        _context = context;
    }

    public Usuario Executar(string nome, string email, Usuario.TipoDepartamento departamento)
    {
        // 1. Aqui ficariam as validações de regra de negócio 
        // (ex: if (email ja existe no banco) throw Exception...)

        // 2. Criação da Entidade
        var novoUsuario = new Usuario(nome, email, departamento);
        
        // 3. Persistência
        _context.Usuarios.Add(novoUsuario);
        _context.SaveChanges();

        return novoUsuario;
    }
}