namespace CalcArea_e_perimetro.Models;

internal class Triangulo : FormaGeometrica
{
    public override double CalculaPerimetro(double lados)
    {
        if (lados != 3)
        {
            Console.WriteLine("Isso não é um triângulo");
            return 0;
        } else
        {
            return base.CalculaPerimetro(lados);
        } 
    }
}
