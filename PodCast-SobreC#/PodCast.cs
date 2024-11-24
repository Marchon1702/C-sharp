class PodCast
{
    public PodCast(string host, string nome) {
        Host = host;
        Nome = nome;
        TotalEpisodios = new List<Episodio>();
    }

    public string Host { get; }
    public string Nome { get; }
    public List<Episodio> TotalEpisodios { get; set; }

    public void AdicionarEpisodio(Episodio episodio)
    {
        TotalEpisodios!.Add(episodio);
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"----------{Nome}----------");
        Console.WriteLine($"Host(s): {Host}");
        if(TotalEpisodios!.Count == 0)
        {
            Console.WriteLine("Ainda não tem espisódios!");
            return;
        }
        Console.WriteLine("\nLista De Episódios\n");
        foreach (Episodio episodio in TotalEpisodios.OrderBy(ep => ep.Ordem))
        {       
            Console.WriteLine($"{episodio.Titulo}");
            Console.WriteLine($"Resumo: {episodio.Resumo}\n");
        }
        Console.WriteLine($"Total de Episódios: {TotalEpisodios.Count}");
        Console.WriteLine("----------------------------------------");
    }
}