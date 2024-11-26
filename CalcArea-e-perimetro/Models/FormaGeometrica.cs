namespace CalcArea_e_perimetro.Models;

internal class FormaGeometrica
{
    public virtual double CalculaArea(double b, double a)
    {
        return b * a;
    } 

    public virtual double CalculaPerimetro(double ladosOuRaio)
    {
        double total = 0;
        for(int i = 0; i < ladosOuRaio; i++)
        {
            Console.Write($"Digite o comprimeto do lado {i+1}: ");
            total += double.Parse(Console.ReadLine()!);
        }
        return total;
    }
}
