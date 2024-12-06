using E_commerce_Loja_de_Roupas.Models;

namespace E_commerce_Loja_de_Roupas.Views.Pages;

internal class AreaDeLogin
{
    private string? usuarioInputado = null;
    private string? senhaInputada = null;
    public bool Liberado { get { return ValidaUsuario(); } }
    public Usuario? Usuario { get; private set; }
    private UsuariosGeral UsuariosGeral = new();

    public void Verificar()
    {
        Console.Clear();
        bool sair = false;
        do
        {
            Console.WriteLine("Você está acessando a Loja Virtual Code Clothes :)\n");

            Console.WriteLine("[1] Continuar com login         [2] Criar uma conta");
            int opcaoEscolhida = int.Parse(Console.ReadLine()!);
            if (opcaoEscolhida == 2) CriarConta();

            Console.WriteLine("\n-------------------Login-Área--------------------");
            Console.Write("Usuário: ");
            usuarioInputado = Console.ReadLine();

            Console.Write("Senha: ");
            senhaInputada = Console.ReadLine();         

            Console.WriteLine("-------------------------------------------------");


            if (Liberado)
            {
                Console.WriteLine($"Bem Vindo {usuarioInputado}!");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("Conta não encontrada :(");
                Console.WriteLine("Continuar Sem Login? ");
                Console.WriteLine("[1] Sim       [2] Não");
                string resposta = Console.ReadLine()!;
                if (resposta == null || resposta == "1") sair = true;
            }
        } while (!Liberado && !sair);
    }

    private bool ValidaUsuario()
    {
        List<Usuario> todosOsUsuarios = UsuariosGeral.RetornarTodosOsUsuarios().ToList();
        foreach (Usuario usuarioAhConferir in todosOsUsuarios)
        {
            if (usuarioAhConferir.Nome == usuarioInputado && usuarioAhConferir.Senha == senhaInputada)
            {
                Usuario = usuarioAhConferir;
                return true;
            }
        }

        Usuario = new("Convidado", "Convidado", "Convidado", new List<Produto>());
        return false;
    }

    public void CriarConta()
    {
        Console.Clear();
        List<Usuario> todosOsUsuarios = UsuariosGeral.RetornarTodosOsUsuarios().ToList();
        bool continuar = false;
        Console.WriteLine("Você está acessando a Loja Virtual Code Clothes :)");
        Console.WriteLine("\n-------------------Criar-uma-Conta--------------------");

        Console.Write("Crie um nome de Usuário: ");
        usuarioInputado = Console.ReadLine();
        do
        {
            if (usuarioInputado == null || usuarioInputado == "")
            {
                Console.WriteLine("Seu nome deve conter no minimo 1 caractere! ");
                usuarioInputado = Console.ReadLine();
            }
            else continuar = true;
        } while (!continuar);

        bool validaUsuarioInputado = todosOsUsuarios.Any(user => user.Nome.Equals(usuarioInputado));
        do
        {
            if (validaUsuarioInputado || usuarioInputado == "Convidado")
            {
                Console.WriteLine("Já existe um Usuário com esse nome!");
                usuarioInputado = Console.ReadLine();
                continuar = false;
            } else continuar = true;
        } while (!continuar);

        Console.Write("Crie uma senha para a sua conta: ");
        senhaInputada = Console.ReadLine();
        do
        {
            if (senhaInputada == "" || senhaInputada == null)
            {
                Console.WriteLine("Sua senha deve ter um valor");
                senhaInputada = Console.ReadLine();
                continuar = false;
            } else continuar = true;
        } while (!continuar);


        Console.Write("Digite o endereço para entrega: ");
        string endereco = Console.ReadLine()!;
        endereco ??= endereco = "Não informado"; // Se o usuário for nulo, enderco recebe "Não informado"!
        Console.WriteLine("Criando Conta...");
        Usuario novoUsuario = new(usuarioInputado!, senhaInputada!, endereco, new List<Produto>());
        UsuariosGeral.AdicionarUsuario(novoUsuario);
        Console.WriteLine("Usuário criado, voltando para área de login...");
        Console.WriteLine("---------------------------------------------------------");
        Thread.Sleep(3000);
        return;       
    }
}
