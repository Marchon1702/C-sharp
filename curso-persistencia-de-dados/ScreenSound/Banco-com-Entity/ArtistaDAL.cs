using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco_Entity;

// CRUD com Entity
internal class ArtistaDAL
{
    private readonly ScreenSoundContext context;

    public ArtistaDAL(ScreenSoundContext context)
    {
        this.context = context;
    }

    public IEnumerable<Artista> Listar()
    { 
        // Retorna a DbSet de context que relaciona a classe Artista do sistema, para a Tabelas do Banco "Artistas".
        return context.Artistas.ToList();
    }

    // Adicionando artista com método direto do Entity...
    public void Adicionar(Artista artista) 
    {
       context.Artistas.Add(artista);
        context.SaveChanges();
    }

    public void Atualizar(Artista artista)
    {
        // Update do Entity realiza a lógica de edição de forma interna dentro do próprio banco...
        context.Artistas.Update(artista);
        context.SaveChanges();
    }

    public void Deletar(Artista artista)
    {
        context.Artistas.Remove(artista);
        context.SaveChanges();
    }

    public Artista? RecuperarPeloNome(string nome)
    { 
        return context.Artistas.FirstOrDefault(artista => artista.Nome.Equals(nome));
    }
}
