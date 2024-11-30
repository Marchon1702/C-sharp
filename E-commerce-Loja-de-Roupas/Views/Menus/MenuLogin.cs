using E_commerce_Loja_de_Roupas.Models;

namespace E_commerce_Loja_de_Roupas.Views.Menus;

internal class MenuLogin : Menu
{
    private string? usuarioInputado = null;
    private string? senhaInputada = null;
    public bool Liberado { get { return ValidaUsuario(); } }
 
    public override void Executar()
    {
        do
        {
            Console.Write("Usuário: ");
            usuarioInputado = Console.ReadLine();

            Console.Write("Senha: ");
            senhaInputada = Console.ReadLine();

            if (Liberado)
            {
                Console.WriteLine($"Bem Vindo {usuarioInputado}!");
                Thread.Sleep(2000);
                Console.Clear();
                MostrarLogo();
            }
            else
            {
                Console.WriteLine("Conta não encontrada :(");
            }

        } while (!Liberado);      
    }

    private bool ValidaUsuario()
    {
        List<Usuario> todosOsUsuarios = (List<Usuario>)UsuariosGeral.RetornarTodosOsUsuarios();
        foreach(Usuario usuarioAhConferir in todosOsUsuarios)
        {
            if(usuarioAhConferir.Nome == usuarioInputado && usuarioAhConferir.Senha == senhaInputada) return true;
        }
        return false;
    }
}
