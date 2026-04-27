using SistemaDeGestaoDeTarefas.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SistemaDeGestaoDeTarefas.Application.UseCases;

public class FazerLoginUseCase
{
    private readonly IUsuarioRepository _repository;
    
    // Essa é a chave mestre do seu sistema. NUNCA a mostre no mundo real!
    // No ambiente corporativo, isso fica num arquivo de configuração escondido.
    private readonly string _chaveSecreta = "UmaChaveMuitoSuperSecretaParaOGestaoDeTarefas123!"; 

    public FazerLoginUseCase(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    // Retorna um objeto dinâmico com o Token e os dados do usuário
    public object Executar(string email, string senha)
    {
        // 1. Busca o usuário pelo e-mail
        var usuario = _repository.ObterPorEmail(email);
        
        // 2. Verifica se o usuário existe e se a senha confere
        if (usuario == null || !BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash))
        {
            throw new Exception("E-mail ou senha inválidos.");
        }

        // 3. Verifica se ele não foi demitido/desativado
        if (!usuario.Ativo)
        {
            throw new Exception("Este usuário foi desativado do sistema.");
        }

        // 4. Se chegou aqui, o login é válido! Vamos gerar o Token JWT.
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_chaveSecreta);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            // O Payload: Informações que vão dentro do crachá
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(8), // O crachá vale por 8 horas
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        // Retorna o token e os dados para o Front-end
        return new 
        { 
            Token = tokenHandler.WriteToken(token),
            Usuario = new { id = usuario.Id, nome = usuario.Nome, departamento = usuario.Departamento }
        };
    }
}