using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;

namespace ScreenSound.Banco_Entity;

// Classe responsavel por se conectar com o banco de dados do SQL server.
public class ScreenSoundContext : DbContext
{
    // Criando uma relação da tabela Artistas para uma prop da aplicação, A PROP DEVE CONTER O MESMO NOME DA TABELA.
    // <Artista> significa que a tabela Artistas se refere a classe da aplição Artista.
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Genero> Generos { get; set; }

    // Connect Timeout=30, esse comando representa o tempo de conexão que o banco levará para se conectar, mas esse comando foi tirado a fim de otimizar o tempo da aula.
    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=screenSoundV0-DB;Integrated Security=True; Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    // Método responsavel por se conectar com um Banco de SqlServer usando EntityFramework
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.
            UseSqlServer(connectionString)
            // Usando carregamento lentos apenas quando for necessário com pacote proxies.
            .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Construindo referências entre entidades Genero e Musica

        // A entidade Musica
        modelBuilder.Entity<Musica>()
            // Tem muitos Generos
            .HasMany(c => c.Generos)  // 'c' refere-se à entidade Musica
            // Com muitas Musicas
            .WithMany(c => c.Musicas);  // 'c' refere-se à entidade Genero

        // Na prática a Classe Musica tem uma prop que é uma lista de Generos e a classe Genero tem uma prop que é uma lista de Musicas.
    }
}
