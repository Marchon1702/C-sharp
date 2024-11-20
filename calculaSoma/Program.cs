// Criar um programa que calcula a soma de todos os elementos inteiros em uma lista.
List<int> listaDeInteiros = new List<int> { 1, 2, 4, 6, 8 };
void calculaSoma()
{
    int soma = 0;
    foreach (int inteiro in listaDeInteiros)
    {
        soma += inteiro;
    }
    Console.WriteLine(soma);
}

calculaSoma();