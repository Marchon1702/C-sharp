// Screen Sound

int opcaoEscolhidaNumerica;
//List<string> listaDeBandas = new List<string>{"eva", "beatles"};

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Djavu", new List<int>{ 7, 6, 9});
bandasRegistradas.Add("Calypso", new List<int>());

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
                AvaliarUmaBanda();
                break;
            case 4:
                MostraMedia();
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
    ExibirTituloDaOpcao("Registro de bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMenuDeOpcoes();
}

void MostrarBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Lista das Bandas Registradas");
    //for (int i = 0; i < listaDeBandas.Count; i++)
    //{   
        //Console.WriteLine($"Banda: {listaDeBandas[i]}");
    //}

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
}

void AvaliarUmaBanda()
{
    // Verificar se a banda existe no dicionário
    // Se sim, atribuir a nota na lista de notas
    // Se não, Exibir uma Mensagem e voltar ao menu da aplicação

    Console.Clear();
    ExibirTituloDaOpcao("Avalie uma Banda");
    Console.Write("Digite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Digite sua nota para {nomeDaBanda}: ");
        int nota = int.Parse(Console.ReadLine())!;
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"Banda {nomeDaBanda} avaliada com sucesso!");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirMenuDeOpcoes();
    }
    else
    {
        Console.WriteLine("Banda não encontrada!\n");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        Console.Clear();
        ExibirMenuDeOpcoes();
    }
}

void MostraMedia()
{
    Console.Clear();
    ExibirTituloDaOpcao("Veja as Avaliações");
    Console.Write("Digite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        if (bandasRegistradas[nomeDaBanda].Count > 0)
        {
           double mediaDaBanda = bandasRegistradas[nomeDaBanda].Average();
           mediaDaBanda = Math.Round(mediaDaBanda, 2);
           Console.WriteLine($"A banda {nomeDaBanda} possui média de: {mediaDaBanda}\n");
        } else
        {
            Console.WriteLine($"A banda {nomeDaBanda} não possui avaliações\n");
        }
    }
    else
    {
        Console.WriteLine($"{nomeDaBanda} não encontrada!\n");
    }

    Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
    Console.ReadKey();
    Console.Clear();
    ExibirMenuDeOpcoes();
}

void ExibirTituloDaOpcao(string titulo) {
    int quantidadeDeLetras = titulo.Length;
    string asterisco = "".PadLeft(quantidadeDeLetras, '*');


    Console.WriteLine(asterisco);
    Console.WriteLine(titulo);
    Console.WriteLine(asterisco + "\n");
}

ExibirMenuDeOpcoes();


