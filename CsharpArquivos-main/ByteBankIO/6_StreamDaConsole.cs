using System.Text;

partial class Program
{
    static void UsarStreamDeEntrada()
    {
        // o fluxoDeEntrada agora recebe um valor digitado pelo usuario...
        using (var fluxoDeEntrada = Console.OpenStandardInput())
        using (var fs = new FileStream("entradaConsole.txt", FileMode.Create))
        {
            // Criando Arquivo a partir do que o usuário digitou...
            var buffer = new byte[1024]; //1kb

            // Esse while serve para que o usuário possa digitar o quanto ele quiser dentro do novo arquivo...
            while (true)
            {
                // bytesLidos recebe um buffer de 1024 bytes == 1Kb
                var byteslidos = fluxoDeEntrada.Read(buffer, 0, 1024);

                // Caso seja lido menos que 1024, o bytesLidos só retornará o número de bytes realmente lidos, então escreverá no arquivo do indice 0 até o número de bytes realmente lidos.

                fs.Write(buffer, 0, byteslidos);
                // Assim que o usuário digita, o Flush despeja os bytes dentro do arquivo que está sendo criado, sem ele o arquivo só seria criado após o fim da execução do programa. Oque nunca seria feito pois o While é sempre true.
                fs.Flush();

                Console.WriteLine($"Bytes lidos na console: {byteslidos}");
            }
        }
    }
}