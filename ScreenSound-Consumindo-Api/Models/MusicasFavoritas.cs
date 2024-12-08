using System.Text.Json;

namespace ScreenSound_Consumindo_Api.Models;

internal class MusicasFavoritas
{
    public string? Nome { get; }
    public List<Musica> ListaDeFavoritas { get; set; }

    public MusicasFavoritas (string nome)
    {
        Nome = nome;
        ListaDeFavoritas = new();
    }

    public void AdicionarMusicaFavorita(Musica musica) => ListaDeFavoritas.Add(musica);

    public void ExibirMusicasFavoritas()
    {
        Console.WriteLine($"Músicas favoritas de {Nome}");
        foreach(Musica musica in ListaDeFavoritas)
        {
            Console.WriteLine($"Música: {musica.Nome} de {musica.Artista}");
        }
    }

    public void GerarArquivoJson()
    {
        string json = JsonSerializer.Serialize(new
        {
            nome = Nome,
            musicasFavoritas = ListaDeFavoritas
        });
        Console.WriteLine(json);
        string nomeDoArquivo = $"favoritas-de-{Nome}.Json";

        File.WriteAllText(nomeDoArquivo, json);
        Console.WriteLine($"{nomeDoArquivo} gerado em {Path.GetFullPath(nomeDoArquivo)}");
    }

    public void GerarDocumentoTXTComAsMusicasFavoritas()
    {
        string nomeDoArquivo = $"musicas-favoritas-{Nome}.txt";
        using (StreamWriter arquivo = new StreamWriter(nomeDoArquivo))
        {
            arquivo.WriteLine($"Músicas favoritas do {Nome}\n");
            foreach (var musica in ListaDeFavoritas)
            {
                arquivo.WriteLine($"- {musica.Nome}");
            }
        }
        Console.WriteLine("txt gerado com sucesso!");
    }
}
