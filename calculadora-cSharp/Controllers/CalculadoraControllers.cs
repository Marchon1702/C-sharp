using calculadora_cSharp.Models;
namespace calculadora_cSharp.Controllers;

internal class CalculadoraControllers
{
    public CalculadoraControllers(Calculadora calculadora) { 
        Calculadora = calculadora;
    }
    public Calculadora Calculadora { get;}

    public void Calcular(List<double> numerosAhCalcular, int operador)
    {
        double total = 0;
        switch (operador)
        {
            case 0: return;
            case 1: 
                total = numerosAhCalcular.Sum();  
                Calculadora.Resultado = total;
                break;
            case 2:
                for (int i = 0; i < numerosAhCalcular.Count; i++)
                {
                    if (i == 0) total = numerosAhCalcular[i];
                    else total -= numerosAhCalcular[i];
                }
                Calculadora.Resultado = total;
                break;
            case 3:
                for (int i = 0; i < numerosAhCalcular.Count; i++)
                {
                    if (i == 0) total = numerosAhCalcular[i];
                    else total *= numerosAhCalcular[i];
                }
                Calculadora.Resultado = total;
                break;
            case 4:
                for(int i = 0; i < numerosAhCalcular.Count; i++)
                {
                    if (i == 0) total = numerosAhCalcular[i];
                    else total /= numerosAhCalcular[i];
                }
                Calculadora.Resultado = total;
                break;
            default: return;
        }
    }
}
