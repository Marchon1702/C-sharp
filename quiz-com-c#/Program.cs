// Crie um programa que implemente um quiz simples de perguntas e respostas.
// Utilize um dicionário para armazenar as perguntas e as respostas corretas.

Dictionary<string, string> perguntasComRespostas = new Dictionary<string, string>
{
    { "Qual a fórmula da água?", "h2o" },
    { "Qual o valor de Pi?", "3,14" },
    { "Qual a capital dos Estatos Unidos?", "Washington" }
};

void mostraPerguntas()
{
    foreach (string pergunta in perguntasComRespostas.Keys)
    {
        Console.WriteLine(pergunta);
        string respostaCerta = perguntasComRespostas[pergunta];
        string resposta = Console.ReadLine()!;

        if(respostaCerta == resposta)
        {
            Console.WriteLine("Acerto mizeravi!"); 
        } else
        {
            Console.WriteLine("Você errou! :(");
        }
    }
}

mostraPerguntas();