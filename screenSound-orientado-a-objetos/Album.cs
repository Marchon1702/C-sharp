class Album
{
    private List<Musica> musicas = new List<Musica>();
    public string Nome { get; set; }
    public int DuracaoTotal => musicas.Sum(musica => musica.Duracao);

    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void ListarMusicas()
    {
        Console.WriteLine($"Lista de Músicas do álbum: {Nome}");
        foreach(Musica musica in musicas)
        {
            Console.WriteLine($"{musica.Nome} \n");
        }
        Console.WriteLine($"Duração total do álbum: {DuracaoTotal}");
    }
}

