using SistemaTarefasCorporativas.Entities;
using Microsoft.EntityFrameworkCore; 
    
namespace SistemaTarefasCorporativas.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Tarefa> Tarefas { get; set; }
}