using bytebank_ATENDIMENTO.bytebank.Atendimento;
using gerador_pix;
Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
//new ByteBankAtendimento().AtendimentoCliente();


Console.WriteLine(GeradorPix.GerarChavePix());

var listaDeChaves = GeradorPix.GerarListaDeChavesPix(5);
foreach(var chave in listaDeChaves)
{
    Console.WriteLine(chave);
}
