namespace calculadora_cSharp.Views;
internal class CalcTemplate
{
    public static void MostraCalculadora()
    {
        Console.WriteLine("╔═══════════════════════════════════╗");
        Console.WriteLine("║           CALCULADORA             ║");
        Console.WriteLine("╠═══════════════════════════════════╣");
        Console.WriteLine("║  Escolha uma operação:            ║");
        Console.WriteLine("║  1 - Adição (+)                   ║");
        Console.WriteLine("║  2 - Subtração (-)                ║");
        Console.WriteLine("║  3 - Multiplicação (*)            ║");
        Console.WriteLine("║  4 - Divisão (/)                  ║");
        Console.WriteLine("║  0 - Sair                         ║");
        Console.WriteLine("╚═══════════════════════════════════╝");
    }
}
