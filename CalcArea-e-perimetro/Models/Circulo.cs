namespace CalcArea_e_perimetro.Models
{
    internal class Circulo : FormaGeometrica
    {
        public override double CalculaArea(double raio, double lados)
        {
            if (lados > 0)
            {
                Console.WriteLine("Isso não é um circulo!");
                return 0;
            }
            return 3.14 * (Math.Pow(raio, 2)); 
        }
        public override double CalculaPerimetro(double raio)
        {
            return 2 * 3.14 * raio;
        }
    }
}
