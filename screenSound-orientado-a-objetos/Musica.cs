class Musica
{
    public string Nome { get; set; }
    public string Artista { get; set; }
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }
    public string Descricao => $"A música {Nome} pertence a banda {Artista}.";

    public void ExibirInfosDaMusica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Duração {Duracao} seg");
        Console.WriteLine($"Descrição: {Descricao}");
        if(Disponivel)
        {
            Console.WriteLine("Ouça agora!");
        } else
        {
            Console.WriteLine("Assine o plano Plus+");
        }
        Console.WriteLine("--------------------------------");
    }
}