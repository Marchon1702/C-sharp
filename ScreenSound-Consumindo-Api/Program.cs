using System.Text.Json;
using ScreenSound_Consumindo_Api.Filtros;
using ScreenSound_Consumindo_Api.Models;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
        //LinqFilter.FiltrarTodosOsGeneros(musicas);
        //LinqOrder.ExibirTodosOsArtistasOrdenados(musicas);
        //LinqFilter.FiltrarProGeneroMusical(musicas, "rock");
        //LinqFilter.FiltrarMusicasPorArtista(musicas, "Michael Jackson");

        MusicasFavoritas minhasFavoritas = new("Matheus");
        minhasFavoritas.AdicionarMusicaFavorita(musicas[9]);
        minhasFavoritas.AdicionarMusicaFavorita(musicas[93]);
        minhasFavoritas.AdicionarMusicaFavorita(musicas[23]);
        minhasFavoritas.AdicionarMusicaFavorita(musicas[308]);
        minhasFavoritas.AdicionarMusicaFavorita(musicas[1977]);

        minhasFavoritas.ExibirMusicasFavoritas();
        minhasFavoritas.GerarArquivoJson();
    }
    catch (Exception ex) 
    {
        Console.WriteLine("Erro na requisição...");
        Console.WriteLine(ex.Message);
    }
}