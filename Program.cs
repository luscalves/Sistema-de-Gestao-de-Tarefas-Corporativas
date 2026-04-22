using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SistemaDeGestaoDeTarefas;
using SistemaDeGestaoDeTarefas.Application.UseCases;
using SistemaDeGestaoDeTarefas.Infrastructure;
using SistemaDeGestaoDeTarefas.UseCases;

var builder = WebApplication.CreateBuilder(args);

// 1. Adiciona o suporte para criarmos nossos Endpoints (Controllers)
builder.Services.AddControllers();

// 👇 CONFIGURAÇÃO DE CORS ADICIONADA AQUI 👇
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontEnd", policy =>
    {
        policy.WithOrigins("http://localhost:5174") // O endereço do seu Vite/React
            .AllowAnyHeader()                     // Permite enviar qualquer dado (como JSON)
            .AllowAnyMethod();                    // Permite POST, GET, PUT, DELETE
    });
});

// 2. Registra o nosso Banco de Dados
builder.Services.AddDbContext<AppDbContext>();

// 3. A Mágica da Injeção de Dependência
// Repositórios agrupados
builder.Services.AddScoped<ITarefaRepository, TarefaPostgresRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioPostgresRepository>();

// UseCases de Tarefa
builder.Services.AddScoped<ConcluirTarefaUseCase>();
builder.Services.AddScoped<CriarTarefaUseCase>();
builder.Services.AddScoped<ListarTarefasUseCase>();
builder.Services.AddScoped<AtualizarTarefaUseCase>();
builder.Services.AddScoped<ExcluirTarefaUseCase>();
builder.Services.AddScoped<ObterTarefaPorIdUseCase>();
builder.Services.AddScoped<DeletarTarefaUseCase>();

// UseCases de Usuário / Atribuição
builder.Services.AddScoped<AtribuirUsuarioUseCase>();
builder.Services.AddScoped<ListarUsuariosUseCase>();
builder.Services.AddScoped<CriarUsuarioUseCase>();

var app = builder.Build();

// 👇 ATIVAÇÃO DA LINHA DE MONTAGEM (PIPELINE) 👇

// 1º O Routing (Avisa o .NET que vamos usar rotas na API)
app.UseRouting();

// 2º O CORS (A barreira de segurança - Tem que ficar EXATAMENTE AQUI!)
app.UseCors("PermitirFrontEnd");

// 3º Autorização (Boa prática manter na ordem, caso você adicione login no futuro)
app.UseAuthorization();

// 4º Mapeia as rotas para os Controllers
app.MapControllers();

// 5º Liga o servidor!
app.Run();