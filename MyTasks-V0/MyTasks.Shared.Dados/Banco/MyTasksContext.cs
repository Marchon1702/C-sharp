using Microsoft.EntityFrameworkCore;
using MyTasks.Shared.Modelos.Modelos;

namespace MyTasks.Shared.Dados.Banco;

public class MyTasksContext : DbContext
{
    public DbSet<Tarefa> Tarefas { get; set; }

    private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyTasks-DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public MyTasksContext(DbContextOptions options) : base(options) { }

    // Esse construtor vazio é necessário para que as novas migrações possam instanciar esse context sem atribuir um argumento
    public MyTasksContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;

        optionsBuilder
            .UseSqlServer(_connectionString)
            .UseLazyLoadingProxies();
    }
}
