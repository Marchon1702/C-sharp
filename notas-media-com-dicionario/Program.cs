// Criar um dicionário que represente um aluno,
// com uma lista de notas, e mostre a média de suas notas na tela.

Dictionary<string, List<int>> notasDoAluno = new Dictionary<string, List<int>>
{
    { "Matheus", new List<int> {8, 9, 5} }
};

void MostrarMedia()
{
    foreach (string aluno in notasDoAluno.Keys)
    {
        List<int> notas = notasDoAluno[aluno];
        double notaMedia = notas.Average();
        Console.WriteLine($"A nota média de {aluno} é {notaMedia}");
        Thread.Sleep(5000);
    }
}

MostrarMedia();

