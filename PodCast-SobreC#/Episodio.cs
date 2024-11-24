class Episodio
{
    public Episodio(string titulo, int ordem, int duracao)
    {
        Titulo = titulo;
        Ordem = ordem;
        Duracao = duracao;
    }

    private List<string> convidados = new List<string>();

    public int Duracao { get; }
    public string Titulo { get; }
    public int Ordem { get; }
    public string Resumo => $"O episódio: {Titulo}, é o episódio de número {Ordem}, tendo uma duração de {Duracao} Min, trazendo como convidados(as):\n{FormataConvidados()}";

    private string FormataConvidados()
    {
        if (convidados.Count == 0) return $"O chat";
        string listaDeConvidados = "";
        foreach (string convidado in convidados)
        {
            listaDeConvidados += $"{convidado}; \n";
        }

        return listaDeConvidados;
    }

    public void AdicionarConvidados(string convidado)
    {
        convidados.Add(convidado);
    }
}