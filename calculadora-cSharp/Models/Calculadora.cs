namespace calculadora_cSharp.Models;

internal class Calculadora
{
    public Calculadora(int operador, List<double> numerosAhCalcular) {
        Operador = operador;
        NumerosAhCalcular = numerosAhCalcular;
        Resultado = 0;
    }

    public List<double> NumerosAhCalcular { get; }
    public int Operador { get; }
    public double Resultado { get; set; }
}
