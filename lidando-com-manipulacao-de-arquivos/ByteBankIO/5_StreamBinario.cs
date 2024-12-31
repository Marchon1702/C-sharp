using System.Text;

partial class Program
{
    // Escruta Binária escreve os dados em forma binária, isso faz com que a memória seja economizada pois strings ocupam mais bytes do que um boleano por exemplo.
    static void EscritaBinaria()
    {
        using (var fs = new FileStream("contaCorrente.txt", FileMode.Create))
        using (var escritor = new BinaryWriter(fs))
        {
            escritor.Write(456);           //número da Agência
            escritor.Write(546544);   //número da conta
            escritor.Write(4000.50); //Saldo
            escritor.Write("Gustavo Braga");
        }
    }

    // O BinaryWriter escreve os arquivo em forma binária, isso faz com que quando o arquivo não tiver o tipo string, se torne mais impossível de ser lido. 

    //O LeituraBinária pega os dados binários dentro do arquivo e seta eles em variáveis, tornando possivel a leitura dos dados
    static void LeituraBinaria()
    {
        using (var fs = new FileStream("contaCorrente.txt", FileMode.Open))
        using (var leitor = new BinaryReader(fs))
        {
            // Para inteiros é pedidos o número de bits que está sendo ocupado
            var agencia = leitor.ReadInt32();
            var conta = leitor.ReadInt32();

            var saldo = leitor.ReadDouble();
            var titular = leitor.ReadString();

            Console.WriteLine($"AG: {agencia}/ Ct: {conta} Saldo: {saldo} --> {titular}");
        }
    }
}