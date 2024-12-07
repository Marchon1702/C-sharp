using System.Text.Json;
using ScreenSound_Consumindo_Api.Models;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;
        musicas[new Random().Next(1, 56)].ExibirDetalhesDaMusica();
    }
    catch (Exception ex) 
    {
        Console.WriteLine("Erro na requisição...");
        Console.WriteLine(ex.Message);
    }
}