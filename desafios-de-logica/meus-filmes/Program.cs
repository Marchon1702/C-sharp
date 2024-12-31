// Criar uma classe que representa um filme, com dados como seu titulo, duração e elenco. Após isso, colocá-la no namespace Alura.Filmes.

//Criar um programa Program.cs, instanciar seus 5 filmes favoritos, guardá-los em uma lista e mostrar as suas informações no console.

//Criar uma classe Artista, que representa uma pessoa que atua em filmes, no namespace Alura.Filmes.A classe deve conter atributos como o nome, idade e uma lista de filmes onde o artista atuou.

//Modificar as classes Artista e Filme do namespace Alura.Filmes para que elas sejam consistentes uma com a outra, ou seja, sempre que for adicionado um artista a um filme, terá de ser adicionado também o filme à lista de filmes do artista.

using Alura.Filmes.Models;

List<Filme> meusFilmes = new();
meusFilmes.Add(new Filme("O Senhor dos Anéis", 240));
meusFilmes.Add(new Filme("Matrix", 120));
meusFilmes.Add(new Filme("A Origem", 110));
meusFilmes.Add(new Filme("Canguru Jack", 128));
meusFilmes.Add(new Filme("As Branquelas", 148));

List<Artista> artistas = new();
artistas.Add(new Artista("Marlon Wayans", 34));
artistas.Add(new Artista("Eddie Murphy", 56));
artistas.Add(new Artista("Leonardo Di Caprio", 47));

foreach (Filme filme in meusFilmes)
{
    foreach (Artista artista in artistas)
    {
        filme.AdicionarArtista(artista);
    }
    Console.WriteLine($"Filme: {filme.Nome}");
    Console.WriteLine($"Duração: {filme.Duracao}");
    Console.WriteLine($"Elenco: {string.Join(", ", filme.Elenco.Select(art => art.Nome))}.\n");
}
Console.WriteLine("-----------------------------------------------------");

foreach (Artista artista in artistas)
{
    Console.WriteLine($"\nTrabalhos de atuação de: {artista.Nome}\n");
    foreach (Filme filme in meusFilmes)
    {
        Console.WriteLine($"{filme.Nome}");
    }
}

Console.WriteLine("-----------------------------------------------------");