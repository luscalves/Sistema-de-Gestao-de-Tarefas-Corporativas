using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SistemaDeGestaoDeTarefas;
using SistemaDeGestaoDeTarefas.Infrastructure;
using SistemaDeGestaoDeTarefas.UseCases;

var builder = WebApplication.CreateBuilder(args);

// 1. Adiciona o suporte para criarmos nossos Endpoints (Controllers)
builder.Services.AddControllers();

// 2. Registra o nosso Banco de Dados
builder.Services.AddDbContext<AppDbContext>();

// 3. A Mágica da Injeção de Dependência: Ensina as conexões
// "Sempre que alguém pedir um ITarefaRepository, entregue um TarefaPostgresRepository"
builder.Services.AddScoped<ITarefaRepository, TarefaPostgresRepository>();

// Registramos também nosso Maestro para que o Controller possa chamá-lo
builder.Services.AddScoped<ConcluirTarefaUseCase>();

var app = builder.Build();

// 4. Mapeia as rotas de internet para os nossos futuros Controllers
app.MapControllers();

// 5. Liga o servidor!
app.Run();