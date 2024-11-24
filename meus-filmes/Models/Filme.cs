namespace Alura.Filmes.Models;

class Filme
{
    public Filme(string nome, int duracao)
    {
        Nome = nome;
        Duracao = duracao;
        Elenco = new();
    }

    public string Nome { get; }
    public int Duracao { get; }
    public List<Artista> Elenco { get; set; }

    public void AdicionarArtista(Artista artista)
    {
        Elenco.Add(artista);
        artista.Filmes.Add(this);
    }
}