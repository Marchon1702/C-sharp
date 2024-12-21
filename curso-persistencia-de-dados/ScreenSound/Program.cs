//using ScreenSound.Banco_AdoNet;
using ScreenSound.Banco_com_Entity;
using ScreenSound.Banco_Entity;
using ScreenSound.Menus;
using ScreenSound.Modelos;


#region // Fazendo a conexão com AdoNet
//try
//{
// A conexão já foi aberta no Método listar então não precisa ser aberta nesse escopo
// Instanciando a classe Connection para ter acesso o método listar
//var artistaDAL = new ArtistaDAL();

// Adicionar adiciona um artista ao banco de dados...
//artistaDAL.Adicionar(new Artista("Jonas Brothers", "São irmãos"));
//artistaDAL.Editar(new Artista("Michael Jackson", "Rei do Pop") { Id = 6});

// Listar retorna uma Lista de Artista instanciados em sua classe...
//    var listaDeArtistas = artistaDAL.Listar();
//    foreach (var artista in listaDeArtistas)
//    {
//        Console.WriteLine(artista);
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion

#region // Fazendo conexão com EntityFramework
//try
//{
//    using var context = new ScreenSoundContext();
//    var artistaDAL = new ArtistaDAL(context);

// Quando formos adicionar um artista ele não deve conter o primary Key definida por nós, apenas no atualizar e deletar que devemos enviar o Id da instacia da classe na aplicação para comparar com o dp banco de dados.
//var novoArtista = new Artista("Pitty Rockeira", "Rockeira braba") { Id = 1004};
//artistaDAL.Adicionar(novoArtista);

//artistaDAL.Atualizar(novoArtista);
//artistaDAL.Deletar(novoArtista);

//var listaDeArtistas = artistaDAL.Listar();

//foreach (var artista in listaDeArtistas)
//{
//    Console.WriteLine(artista);
//}

//var artistaRecuperado = artistaDAL.RecuperarPeloNome("Michael Jackson");

//Console.WriteLine($"\n\n {artistaRecuperado}");
//}
//catch(Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion


var context = new ScreenSoundContext();
var artistaDAL = new DAL<Artista>(context);

Dictionary<int, Menu> opcoes = new();
opcoes.Add(1, new MenuRegistrarArtista());
opcoes.Add(2, new MenuRegistrarMusica());
opcoes.Add(3, new MenuMostrarArtistas());
opcoes.Add(4, new MenuMostrarMusicas());
opcoes.Add(-1, new MenuSair());

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 3.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um artista");
    Console.WriteLine("Digite 2 para registrar a música de um artista");
    Console.WriteLine("Digite 3 para mostrar todos os artistas");
    Console.WriteLine("Digite 4 para exibir todas as músicas de um artista");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
        menuASerExibido.Executar(artistaDAL);
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

ExibirOpcoesDoMenu();
