namespace Alura.Filmes.Models;
class Artista {
    public Artista(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
        Filmes = new();
    }

    public string Nome { get; }
    public int Idade { get; }
    public List<Filme> Filmes { get; set; }
}
