namespace SistemaDeGestaoDeTarefas.Domain.Entities;

public class Usuario
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    
    // NOVO CAMPO: Guardará o Hash, nunca a senha pura!
    public string SenhaHash { get; private set; } 
    
    public TipoDepartamento Departamento { get; private set; }
    public bool Ativo { get; private set; } 

    public enum TipoDepartamento
    {
        Suporte,
        Desenvolvimento,
        Financeiro
    }
    
    // Atualize o construtor para receber a senha já criptografada
    public Usuario(string nome, string email, string senhaHash, TipoDepartamento departamento)
    {
        Validar(nome, email);
        
        this.Nome = nome;
        this.Email = email;
        this.SenhaHash = senhaHash;
        this.Departamento = departamento;
        this.Ativo = true;
    }

    public void MudarDepartamento(TipoDepartamento novoDepartamento) { this.Departamento = novoDepartamento; }
    public void Desativar() { this.Ativo = false; }

    private void Validar(string nome, string email)
    {
        if (string.IsNullOrWhiteSpace(nome)) throw new Exception("O nome não pode ser vazio.");
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@")) throw new Exception("E-mail inválido.");
    }
}