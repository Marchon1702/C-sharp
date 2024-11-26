namespace CalcArea_e_perimetro.Models;

internal class Quadrado : FormaGeometrica
{
    public override double CalculaArea(double b, double a)
    {
        if (b != a)
        {
            Console.WriteLine("Isso não é um quadrado!");
            return 0;
        }
        return b * a;
    }

    public override double CalculaPerimetro(double ladosOuRaio)
    {
        List<double> lados = new();
        for (int i = 0; i < ladosOuRaio; i++)
        {
            Console.Write($"Digite o comprimeto do lado {i + 1}: ");
            lados.Add(double.Parse(Console.ReadLine()!));
            if (i > 0)
            {
                if (lados[i] != lados[i - 1])
                {
                    Console.WriteLine("Isso não é um quadrado!");
                    return 0;
                }
            }
        }
        return lados.Sum();
    } 
}
