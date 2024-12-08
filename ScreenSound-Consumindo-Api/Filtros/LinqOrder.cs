using ScreenSound_Consumindo_Api.Models;

namespace ScreenSound_Consumindo_Api.Filtros;

internal class LinqOrder
{
    public static void ExibirTodosOsArtistasOrdenados(List<Musica> musicas)
    {
        var artistasOrdenados = musicas.OrderBy(musica => musica.Artista).Select(musica => musica.Artista).Distinct().ToList();
        foreach(string artista in artistasOrdenados)
        {
            Console.WriteLine($"- {artista}");
        }
    }
}
