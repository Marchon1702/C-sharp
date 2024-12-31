using ByteBankIO;

partial class Program
{
    static void ConvertendoStringParaConta(string linha)
    {
        // 375,4644,2483.13,Jonatan Silva
        var campos = linha.Split(',');
        var agencia = int.Parse(campos[0]);
        var conta = int.Parse(campos[1]);
        var saldo = double.Parse(campos[2].Replace(".", ","));
        var nome = campos[3];

        var contaCorrente = new ContaCorrente(agencia, conta);
        contaCorrente.Depositar(saldo);

        var cliente = new Cliente();
        cliente.Nome = nome;

        contaCorrente.Titular = cliente;

        var exibirConta = $"Ag: {contaCorrente.Agencia} Conta: {contaCorrente.Numero} Saldo: {contaCorrente.Saldo} Titular: {contaCorrente.Titular.Nome}";
        Console.WriteLine(exibirConta);
    }
}
