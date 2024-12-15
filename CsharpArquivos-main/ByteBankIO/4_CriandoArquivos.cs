using System.Text;

partial class Program
{

    // Criando arquivos com FileStream
    static void CriarArquivo()
    {
        //LidandoComFileStreamDiretamente();
        //LidandoComStreamReader();

        var enderecoNovoArquivo = "contasExportadasCsv.csv";

        // Usando o FileMode.Create ao invés de Open
        using (var fluxoDeArquivo = new FileStream(enderecoNovoArquivo, FileMode.Create))
        {
            var arquivoContaAhExportar = "123, 3456, 97890.78, Matheus";
            // Criando encoding para capturar Bytes do arquivo
            var enconding = Encoding.UTF8;
            // Capturando bytes
            var buffer = enconding.GetBytes(arquivoContaAhExportar);

            // Escrevendo os bytes com o método write, que recebe os mesmo argumentos do Read.
            fluxoDeArquivo.Write(buffer, 0, buffer.Length);
        }
    }

    // StreamWriter é uma versão simplificada do código do método acima
    static void CriarArquivoComStreamWriter()
    {
        var enderecoNovoArquivo = "contasExportadasCsv.csv";

        // Declarando que vamos criar um novo arquivo
        // Adendo: Create, cria um arquivo, caso o seu nome já exista em algum arquivo, ele sobreescreve esse arquivo.
        // CreateNew, Cria um arquivo apenas se o seu nome não existir, ele é incapaz de sobreescrever um arquivo, mais indicado para situações onde não queremos correr o risco de alterar algum arquivo existente da máquina.
        using (var fluxoDeArquivo = new FileStream(enderecoNovoArquivo, FileMode.Create))
        {
            // Utilizando o StreamWriter
            using(var escritor = new StreamWriter(fluxoDeArquivo))
            {
                // Basta escrever o conteúdo do novo arquivo...
                escritor.Write("567, 3420, 7890.78, Cabrito");
            }
        }
    }

    // Esse teste sem o método Flush(), escreve todo o conteúdo no documento e depois envia para o Stream adicionar ao arquivo. Isso pode ser prejudicial quando precisamos de diagnósticos instântaneos.
    static void TestaEscrita()
    {
        var caminhoNovoArquivo = "teste.txt";

        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew))
        using (var escritor = new StreamWriter(fluxoDeArquivo))
        {
            for (int i = 0; i < 1000000; i++)
            {
                escritor.WriteLine($"Linha {i}");
                // O método Flush limpa os buffers do fluxo fazendo com que os dados armazenados nele sejam gravados no arquivo;
                escritor.Flush(); // Desepeja os bytes já lidos para o FileStream
                Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter...");
                Console.ReadLine();
            }
        }
    }
}