// Criar um programa que simule um sistema de login utilizando um dicionário
// para armazenar nomes de usuário e senhas.

Dictionary<string, string> userAndPassword = new Dictionary<string, string>
{
    { "Matheus", "matheus2000"}
};

Console.WriteLine("*****************");
Console.WriteLine("BarberShopManager");
Console.WriteLine("*****************\n");

Console.Write("Digite seu nome de usuário: ");
string username = Console.ReadLine()!;

if(userAndPassword.ContainsKey(username))
{
    Console.Write("Digite sua senha: ");
    string senhaDigitada = Console.ReadLine()!;

    if (senhaDigitada == userAndPassword[username])
    {
        Console.WriteLine($"Seja Bem vindo {username}");
    } else
    {
        Console.WriteLine("Senha incorreta, tente novamente mais tarde!");
    }

} else
{
    Console.WriteLine("Usuário não encontrado!");
}

   





