//  o programa gera um número aleatório entre 1 e 100 e o usuário deve adivinhar qual é esse
//  número. O programa utiliza o if-else e switch case para verificar se o número digitado
//  pelo usuário é maior ou menor do que o número gerado pelo programa.
// O programa também utiliza o conceito de laço de repetição do-while para permitir que o
// usuário faça várias tentativas até acertar o número. Quando o usuário acertar o número,
// o jogo acaba e o programa exibe uma mensagem indicando que o jogo acabou.

Random random = new Random();
int number = random.Next(1, 101);
bool finished = false;

do
{
    Console.WriteLine("Guess The Number");
    Console.WriteLine("Advinhe o número que estou pensando: ");
    string triedNumberStr = Console.ReadLine()!;
    int triedNumber = int.Parse(triedNumberStr);

    CheckTriedNumber(triedNumber);

} while (!finished);


void CheckTriedNumber(int triedNumberParam)
{
    if(triedNumberParam < number)
    {
        Console.WriteLine("Estou pensando em um número maior...");
    } else if(triedNumberParam > number)
    {
        Console.WriteLine("Estou pensando em um número menor...");
    } else
    {
        Console.WriteLine($"Parabéns, eu realmente pensei no {number}");
        finished = true;
    }
}
