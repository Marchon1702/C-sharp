class Musica
{
    public string nome;
    public string artista;
    public int duracao;
    public bool disponivel;

    public void ExibirInfosDaMusica()
    {
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Artista: {artista}");
        Console.WriteLine($"Duração {duracao} seg");
        if(disponivel)
        {
            Console.WriteLine("Ouça agora!");
        } else
        {
            Console.WriteLine("Assine o plano Plus+");
        }
    }
}