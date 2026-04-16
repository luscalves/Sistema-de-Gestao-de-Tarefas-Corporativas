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
        policy.WithOrigins("http://localhost:5173") // O endereço do seu Vite/React
            .AllowAnyHeader()                     // Permite enviar qualquer dado (como JSON)
            .AllowAnyMethod();                    // Permite POST, GET, PUT, DELETE
    });
});

// 2. Registra o nosso Banco de Dados
builder.Services.AddDbContext<AppDbContext>();

// 3. A Mágica da Injeção de Dependência
builder.Services.AddScoped<ITarefaRepository, TarefaPostgresRepository>();

builder.Services.AddScoped<ConcluirTarefaUseCase>();
builder.Services.AddScoped<CriarTarefaUseCase>();
builder.Services.AddScoped<ListarTarefasUseCase>();
builder.Services.AddScoped<AtualizarTarefaUseCase>();
builder.Services.AddScoped<ExcluirTarefaUseCase>();
builder.Services.AddScoped<ObterTarefaPorIdUseCase>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioPostgresRepository>();
builder.Services.AddScoped<AtribuirUsuarioUseCase>();

var app = builder.Build();

// 👇 ATIVAÇÃO DO CORS ADICIONADA AQUI 👇
// AVISO IMPORTANTE: O UseCors TEM que ficar antes do MapControllers!
app.UseCors("PermitirFrontEnd");

// 4. Mapeia as rotas de internet para os nossos futuros Controllers
app.MapControllers();

// 5. Liga o servidor!
app.Run();