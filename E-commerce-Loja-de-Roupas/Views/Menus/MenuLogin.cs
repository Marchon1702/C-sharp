using E_commerce_Loja_de_Roupas.Models;

namespace E_commerce_Loja_de_Roupas.Views.Menus;

internal class MenuLogin : Menu
{
    private string? usuarioInputado = null;
    private string? senhaInputada = null;
    public bool Liberado { get { return ValidaUsuario(); } }
    public Usuario Usuario { get; private set; }

    public override void Executar() 
    {    
        bool sair = false;
        do
        {
            base.Executar();
            Console.WriteLine("-------------------Login-Área--------------------");
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
        UsuariosGeral usuariosGeral = new ();
        List<Usuario> todosOsUsuarios = usuariosGeral.RetornarTodosOsUsuarios().ToList();
        foreach(Usuario usuarioAhConferir in todosOsUsuarios)
        {
            if (usuarioAhConferir.Nome == usuarioInputado && usuarioAhConferir.Senha == senhaInputada) 
            {
                Usuario = usuarioAhConferir;
                return true;
            } 
        }
        return false;
    }
}
