
using ScreenSound_Consumindo_Api.Models;

namespace ScreenSound_Consumindo_Api.Filtros;

internal class LinqFilter
{
    public static void FiltrarTodosOsGeneros(List<Musica> musicas)
    {
        var todosOsGenerosMusicais = musicas.Select(musica => musica.Genero).Distinct().ToList();
        foreach(string musica in todosOsGenerosMusicais)
        {
            Console.WriteLine(musica);
        }
    }

    public static void FiltrarProGeneroMusical(List<Musica> musicas, string genero)
    {
        var artistasFiltradosPorGenero = musicas.Where(musica => musica.Genero!.Contains(genero)).Select(musica => musica.Artista).Distinct().ToList();
        foreach (string artista in artistasFiltradosPorGenero)
        {
            Console.WriteLine(artista);
        }
    }

    public static void FiltrarMusicasPorArtista(List<Musica> musicas, string artista)
    {
        var musicasDoArtista = musicas.Where(musica => musica.Artista!.Equals(artista)).ToList();

        Console.WriteLine($"Musica de {artista}");

        foreach(Musica musica in musicasDoArtista)
        {
            Console.WriteLine($"- {musica.Nome}");
        }
    }

    public static void FiltrarMusicaEmCSustenido(List<Musica> musicas)
    {
        var musicasEmCSharp = musicas.Where(musica => musica.Tonalidade.Equals("C#"));
        foreach (Musica musicaFiltrada in musicasEmCSharp)
        {
            Console.WriteLine(musicaFiltrada.Nome);
            Console.WriteLine(musicaFiltrada.Tonalidade);
        }
    }
}
