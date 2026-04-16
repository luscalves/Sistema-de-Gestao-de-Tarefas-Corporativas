namespace SistemaDeGestaoDeTarefas.Domain.Entities;

public class Usuario
{
    public int Id{get; private set;}
    public string Nome{get; private set;}
    public string Email{get; private set;}
    public TipoDepartamento Departamento{get; private set;}

    public enum TipoDepartamento
    {
        Suporte,
        Desenvolvimento,
        Financeiro
    }
    
    public Usuario(string nome, string email,  TipoDepartamento departamento)
    {
        this.Nome = nome;
        this.Email = email;
        this.Departamento = departamento;
    }
}