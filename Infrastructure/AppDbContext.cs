
using Microsoft.EntityFrameworkCore;
using SistemaDeGestaoDeTarefas.Entities;

namespace SistemaDeGestaoDeTarefas.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=SistemaGestaoTarefas;Username=postgres;Password=Beatriz321");
    }
}