using SistemaDeGestaoDeTarefas.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SistemaDeGestaoDeTarefas.Application.UseCases;

public class FazerLoginUseCase
{
    private readonly IUsuarioRepository _repository;

    private readonly string _chaveSecreta = "UmaChaveMuitoSuperSecretaParaOGestaoDeTarefas123!"; 

    public FazerLoginUseCase(IUsuarioRepository repository)
    {
        _repository = repository;
    }

    public object Executar(string email, string senha)
    {
        var usuario = _repository.ObterPorEmail(email);
        
        if (usuario == null || !BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash))
        {
            throw new Exception("E-mail ou senha inválidos.");
        }

        if (!usuario.Ativo)
        {
            throw new Exception("Este usuário foi desativado do sistema.");
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_chaveSecreta);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(8), 
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new 
        { 
            Token = tokenHandler.WriteToken(token),
            Usuario = new { id = usuario.Id, nome = usuario.Nome, departamento = usuario.Departamento }
        };
    }
}
