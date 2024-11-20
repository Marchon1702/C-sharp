// Criar um programa que, dado a entrada de dados de um número n inteiro,
// a partir do teclado, exibir a n-ésima posição de uma lista.

string[] nomes = ["Matheus", "Rayssa", "Vera", "Thais", "Ivisson", "Alice", "Isadora"];

Console.Write("Escolha a posição do vetor que deseja acessar: ");
string posicaoStr = Console.ReadLine()!;
int ehNesimaPosicao = int.Parse(posicaoStr);

if(ehNesimaPosicao < nomes.Length && ehNesimaPosicao >= 0)
{
    Console.WriteLine(nomes[ehNesimaPosicao]);
} else
{
    Console.WriteLine("A lista não possui essa poosição!");
}

