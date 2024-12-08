using System.Text.Json.Serialization;

namespace ScreenSound_Consumindo_Api.Models;

internal class Musica
{
    private string[] tonalidades = { "C", "C#", "D", "Eb", "E", "F", "F#", "G", "Ab", "A", "Bb", "B" };

    [JsonPropertyName("song")]
    public string? Nome { get; set; }
    [JsonPropertyName("artist")]
    public string? Artista { get; set; }
    [JsonPropertyName("genre")]
    public string? Genero { get; set; }
    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; }
    [JsonPropertyName("key")]
    public int Key { get; set; }

    public string Tonalidade { get 
        {
            return tonalidades[Key];
        } 
    }

    public void ExibirDetalhesDaMusica()
    {
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Gênero: {Genero}");
        Console.WriteLine($"Duração: {Duracao / 1000} segs");
        Console.WriteLine($"Tom: {Tonalidade}");
    }
}
