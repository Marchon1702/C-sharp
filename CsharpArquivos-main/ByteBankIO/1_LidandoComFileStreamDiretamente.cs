using System.Text;
using ByteBankIO;

// Partial serve para lidar com um único contéudo separado por mais de um arquivo, ou seja, a class Programa marcada como partial aqui, significa que ela é somente uma parte da class e que essa mesma classe pode receber continuações em outros arquivos. Todas as classes Program devem receber o partial quando declarados em arquivos diferentes.
partial class Program
{
    static void LidandoComFileStreamDiretamente()
    {
        var enderecoDoArquivo = "C:\\Users\\Matheus\\source\\repos\\C-sharp\\CsharpArquivos-main\\contas.txt";
        var bytesLidos = -1;

        // Usando o "using" como tratamento de exeções, ele verifica se a variavel fluxoDoArquivo é nula e executa o código caso ela não seja.
        // Com o using o Close é implicitamente aplicado.
        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
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
                ExibirBytesLidos(buffer, bytesLidos);
                Console.WriteLine($"\n Lidos {bytesLidos}");
            }

            // Fecha o arquivo para que ele possa ser modificado caso seja preciso.
            //fluxoDoArquivo.Close();
        }
    }

    static void ExibirBytesLidos(byte[] buffer, int bytesLidos)
    {

        // Utf8 é uma extensão da tabela de caracteres ASCII, ele serve para que possamos acessar caracteres como letras com acento entre outros que a lingua inglesa não possui. Poderiamos trabalhar diretamente com Enconding da ASCII, mas seria forma limitada.

        // Ex: Usando o Encoding padrão ASCII: var encoding = Encoding.ASCII;

        // uft8 usa esquema de codificação unicode.
        var utf8 = new UTF8Encoding();
        // O Read quando sobram bytes repete os dados do buffer nos bytes restantes e acaba gerando uma repetição de dados, porém ele retorna o número real de bytes dos novos dados lidos, então o getString está sendo informado que ele deve ler o buffer o indice 0 até o numero real de bytes lidos.  
        string texto = utf8.GetString(buffer, 0, bytesLidos);
        Console.WriteLine(texto);

        //foreach (byte bufferAtual in buffer)
        //{          
        //    Console.Write(bufferAtual + " ");
        //}
        //Console.WriteLine($"\n\n {buffer.Length} \n\n");
    }
}