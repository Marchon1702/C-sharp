// Criar uma variável chamada notaMedia e atribua um valor inteiro a ela.
// Caso seu valor seja maior ou igual a 5,escreva na tela
// "Nota suficiente para aprovação".

Console.Write("Adicione sua nota: ");
string notaMedia = Console.ReadLine()!;
int notaMediaInt = int.Parse(notaMedia);

if(notaMediaInt < 5 )
{
    Console.WriteLine("Você foi reprovado!");
} else
{
    Console.WriteLine("Parbéns, você passou!");
}
