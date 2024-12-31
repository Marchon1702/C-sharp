using calculadora_cSharp.Views;
using calculadora_cSharp.Models;
using calculadora_cSharp.Controllers;

Calculadora calculadora;
    List<double> CapturaNumeros()
    {
        List<double> numerosAhCalcular = new();
        bool finishedInputing = false;
        do
        {
            Console.Write("Numero: ");
            double numero = double.Parse(Console.ReadLine()!);
            numerosAhCalcular.Add(numero);
            Console.WriteLine("Calcular Agora? Digite: S/N");
            if (Console.ReadLine() == "S") finishedInputing = true;
            else finishedInputing = false;
        }
        while (!finishedInputing);

        return numerosAhCalcular;
    }

    void MostraResultado(double resultado)
    {
        Console.Clear();
        int largura = 35;
        string textoCentralizado = resultado.ToString().PadLeft((largura + resultado.ToString().Length) / 2).PadRight(largura);

        Console.WriteLine(
        @$"╔═══════════════════════════════════╗
║             RESULTADO             ║
╠═══════════════════════════════════╣
║{textoCentralizado}║
╚═══════════════════════════════════╝
");

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
        Console.Clear();
        CalcTemplate.MostraCalculadora();

    }

    void Executar()
    {
        CalcTemplate.MostraCalculadora();
        Console.Write("Escolha uma das opções acima: ");
        int operador = int.Parse(Console.ReadLine()!);
        if (operador >= 0 && operador <= 4)
        {
            if (operador == 0) return;
            calculadora = new Calculadora(operador, CapturaNumeros());
            CalculadoraControllers calcControl = new(calculadora);
            calcControl.Calcular(calculadora.NumerosAhCalcular, operador);
            MostraResultado(calculadora.Resultado);
        }
        else
        {
            Console.WriteLine("Opção inexistente");
            Thread.Sleep(2000);
            Console.Clear();
            CalcTemplate.MostraCalculadora();
        }
    }

    Executar();






 


