//Criar uma classe que representa uma conta bancária, com um número indicador, titular, saldo e senha.
//Desenvolver um método da classe Conta que exibe suas informações.

class Conta
{
    public int numeroDaConta;
    public string nomeDoTitular;
    public int senha;

    public void mostrarDadosConta()
    {
        Console.WriteLine($@"
Conta: {numeroDaConta}
Titular: {nomeDoTitular}
Senha: {senha}
        ");
    }
}