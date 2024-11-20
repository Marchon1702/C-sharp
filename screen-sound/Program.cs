// Screen Sound

int opcaoEscolhidaNumerica;
List<string> listaDeBandas = new List<string>{"eva", "beatles"};

void ExibirLogo()
{
    Console.Clear();
    string mensagemDeBoasVindas = "Seja Bem Vindo ao Screen Sound!";
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirMenuDeOpcoes()
{
    do
    {
        ExibirLogo();
        Console.WriteLine("\nDigite 1 para registrar uma banda");
        Console.WriteLine("Digite 2 para mostrar todas as bandas");
        Console.WriteLine("Digite 3 para avaliar uma banda");
        Console.WriteLine("Digite 4 para exibir a média de uma banda");
        Console.WriteLine("Digite -1 para sair");

        Console.Write("Escolha sua opção: ");
        string opcaoEscolhida = Console.ReadLine()!;
        opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

        switch (opcaoEscolhidaNumerica)
        {
            case 1:
                RegistrarBanda();
                break;
            case 2:
                MostrarBandas();
                break;
            case 3:
                Console.WriteLine("Você escolheu a opção Avaliar uma banda.");
                break;
            case 4:
                Console.WriteLine("Você escolheu a opção Exibir a média de uma banda.");
                break;
            case -1:
                Console.WriteLine("Tchau Tchau :)");
                break;
            default:
                Console.WriteLine("Opção Inválida. Tente novamente.");
                break;
        }

    } while (opcaoEscolhidaNumerica != -1);
}

void RegistrarBanda()
{
    Console.Clear();
    Console.WriteLine("***************************");
    Console.WriteLine("Registro de bandas");
    Console.WriteLine("***************************\n");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    listaDeBandas.Add(nomeDaBanda);
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMenuDeOpcoes();
}

void MostrarBandas()
{
    Console.Clear();
    Console.WriteLine("*****************************");
    Console.WriteLine("Lista de bandas Registradas");
    Console.WriteLine("*****************************\n");
    //for (int i = 0; i < listaDeBandas.Count; i++)
    //{   
        //Console.WriteLine($"Banda: {listaDeBandas[i]}");
    //}

    foreach (string banda in listaDeBandas)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
}

ExibirMenuDeOpcoes();

