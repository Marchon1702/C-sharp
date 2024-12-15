partial class Program
{

    // StreamReader é uma versão mais automatizada de FileStream...
    static void LidandoComStreamReader()
    {
        var enderecoDoArquivo = "C:\\Users\\Matheus\\source\\repos\\C-sharp\\CsharpArquivos-main\\contas.txt";

        using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            // StreamReader faz por baixo dos panos oque o método LidandoComFileStreamDiretamente faz, ele os bytes de um arquivo e converte para caracteres com utf8.
            var leitor = new StreamReader(fluxoDeArquivo);
            string texto;
            // Retorna a primeira linha do arquivo
            //texto = leitor.ReadLine();

            // Lê o arquivo todo até o final, adendo: Ele não faz o fluxoDeArquivo, ou seja, ele lê o aequivo todo de uma vez.
            // texto = leitor.ReadToEnd();

            // Lógica para criar um fluxo de arquivos

            // Enquanto a leitura não chegar no final, leia uma linha do arquivo
            // Essencial para lidar com arquivos muito grandes.
            while (!leitor.EndOfStream)
            {
                texto = leitor.ReadLine()!;
                ConvertendoStringParaConta(texto);
            }
        }
    }
}