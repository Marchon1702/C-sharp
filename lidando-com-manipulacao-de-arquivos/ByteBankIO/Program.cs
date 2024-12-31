using System.Text;
using ByteBankIO;

partial class Program
{
    static void Main(string[] args)
    {
        //LidandoComFileStreamDiretamente();
        //LidandoComStreamReader();

        //CriarArquivo();
        //CriarArquivoComStreamWriter();
        //TestaEscrita();

        // Lidando com dados de forma binária...

        //EscritaBinaria();
        //LeituraBinaria();

        //UsarStreamDeEntrada();

        // Conta quantas linhas um determinado arquivo possui...
        var linhas = File.ReadAllLines("contas.txt");
        Console.WriteLine(linhas.Length);

        /*
        foreach (var linha in linhas)
        {
            Console.WriteLine(linha);
        }
        */

        // Conta quantos bytes um determinado aquivo possui
        var bytesArquivo = File.ReadAllBytes("contas.txt");
        Console.WriteLine($"Arquivo contas.txt possui {bytesArquivo.Length} bytes");

        // Escreve um texte diretamente em um arquivo...
        File.WriteAllText("escrevendoComClasseFile.txt", "Testando File.WriteAllText");

        Console.WriteLine("Aplicação Finalizada ...");

        Console.ReadLine();
    }
}