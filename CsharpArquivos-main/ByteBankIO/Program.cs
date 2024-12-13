using System.Text;
using ByteBankIO;

class Program
{
    static void Main(string[] args)
    {
        var enderecoDoArquivo = "C:\\Users\\Matheus\\source\\repos\\C-sharp\\CsharpArquivos-main\\contas.txt";
        var bytesLidos = -1;
        var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open);
        
        var buffer = new byte[1024]; // Variável buffer, normalmente utilizada para armazenar um conjuto de dados de um arquivo temporariamente.
        // 1024 == 1KByte

        // public override void Read(byte[] array, int offSet, int count);
        // Devoluções de um Read:
        // 0 número total de bytes lidos do buffer (Quando um buffer retorna 0, significa que não o arquivo terminou de ser lido). Isso poderá ser menor que o número de
        // bytes solicitado se esse número de bytes não estiver disponível no momento, ou
        //zero, se o final do fluxo for atingido

        while (bytesLidos != 0) // Se os bytes lidos são diferente de 0, então ainda tem arquivos a serem lidos.
        {
            
            bytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024); // Leia o fluxoDoArquivo com base no array buffer, começando da posição 0 até a 1024 e retorne quantos bytes foram lidos;
            ExibirBytesLidos(buffer);
        }
    }

    static void ExibirBytesLidos(byte[] buffer)
    {

        // Utf8 é uma extensão da tabela de caracteres ASCII, ele serve para que possamos acessar caracteres como letras com acento entre outros que a lingua inglesa não possui. Poderiamos trabalhar diretamente com Enconding da ASCII, mas seria forma limitada.

        // Ex: Usando o Encoding padrão ASCII: var encoding = Encoding.ASCII;

        // uft8 usa esquema de codificação unicode.
        var utf8 = new UTF8Encoding();
        string texto = utf8.GetString(buffer);
        Console.WriteLine(texto);

        //foreach (byte bufferAtual in buffer)
        //{          
        //    Console.Write(bufferAtual + " ");
        //}
        //Console.WriteLine($"\n\n {buffer.Length} \n\n");
    }
}