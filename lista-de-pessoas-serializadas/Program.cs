//Criar um programa que permite ao usuário inserir informações de várias pessoas, armazena essas informações em uma lista, serializa a lista em formato JSON e salva em um arquivo.

//Criar um programa que lê um arquivo JSON contendo informações de várias pessoas, desserializa essas informações em uma lista e exibe na tela.

//Criar um programa que lê um arquivo JSON contendo informações de várias pessoas, permite ao usuário inserir uma idade e exibe as pessoas com aquela idade.

using lista_de_pessoas_serializadas.Models;

//List<Pessoa> pessoas = new();

//bool finalizado = false;
//do
//{
//    Console.WriteLine("Registre-se...");
//    Console.Write("Nome: ");
//    string nome = Console.ReadLine();
//    Console.Write("Idade: ");
//    int idade = int.Parse(Console.ReadLine());
//    if(idade < 1)
//    {
//        Console.WriteLine("Idade Inexistente...");
//        return;
//    }
//    Console.Write("Email: ");
//    string email = Console.ReadLine();
//    if (!email.Contains("@"))
//    {
//        Console.WriteLine("Insira um email válido!");
//        return;
//    }

//    pessoas.Add(new Pessoa
//    {
//        Nome = nome,
//        Idade = idade,
//        Email = email
//    });

//    Console.WriteLine("Finalizar registros [S]       [N] Continuar Registrando");
//    string fim = Console.ReadLine();
//    if(fim == "S" || fim == "s") finalizado = true;
//} while (finalizado == false);

//Pessoa.SerializarRegistrosEGerarArquivo(pessoas);

List<Pessoa> listaDePessoas = Pessoa.DeserializaRegistrosDeUmArquivo("lista-de-pessoas.json");
Thread.Sleep(3000);
Console.Clear();
Console.WriteLine("Filtrados por idade...\n");
Pessoa.FiltrarPorIdade(listaDePessoas, 12);
