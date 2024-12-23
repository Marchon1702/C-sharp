using ScreenSound.Banco_com_Entity;
using ScreenSound.Banco_Entity;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicasPorAnoDeLancamento : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Exibir músicas por ano de lançamento");
        Console.Write("Digite o ano de lançamento:");
        string anoLancamento = Console.ReadLine()!;

        var musicaDAL = new DAL<Musica>(new ScreenSoundContext());
        var musicasPorAnoDigitado = musicaDAL.ListarPor(musica => musica.AnoLancamento == Convert.ToInt32(anoLancamento));

        if(musicasPorAnoDigitado is not null)
        {
            foreach (var musica in musicasPorAnoDigitado)
            {
                Console.WriteLine($"{musica.Nome} -- Ano: {musica.AnoLancamento}");
            }
        } else Console.WriteLine("Não existem músicas do ano digitado em novo banco :(");

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
