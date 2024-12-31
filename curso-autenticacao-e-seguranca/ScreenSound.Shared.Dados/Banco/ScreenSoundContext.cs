using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using ScreenSound.Shared.Dados.Modelos;
using ScreenSound.Shared.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
// Usando Identity Com Entity Framework nós mudamos a herança do contexto ele passa não só a herdar de DBContext mas também de Identity.
// Junto com essa mudança devemos definir a classe que está lidando com o modelo de Pessoas com acesso e os perfis de acesso além do tipo de suas chaves primarias, nessa caso int.
public class ScreenSoundContext: IdentityDbContext<PessoaComAcesso, PerfilDeAcesso, int>
{
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Genero> Generos { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=screenSoundV0-DB;Integrated Security=True; Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public ScreenSoundContext()
    {
        
    }
    public ScreenSoundContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        optionsBuilder
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Musica>()
       .HasOne(m => m.Artista)                // Uma música possui um artista
       .WithMany(a => a.Musicas)             // Um artista pode ter várias músicas
       .HasForeignKey(m => m.ArtistaId)      // Chave estrangeira
       .OnDelete(DeleteBehavior.Cascade);    // Exclusão em cascata

        modelBuilder.Entity<Musica>()
            .HasMany(c => c.Generos)
            .WithMany(c => c.Musicas);
    }

}
