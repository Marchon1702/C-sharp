using E_commerce_Loja_de_Roupas.Models;
using E_commerce_Loja_de_Roupas.Views.Pages;

namespace E_commerce_Loja_de_Roupas.Views;

internal class NavegacaoGeral
{
    public NavegacaoGeral(Usuario usuarioLogado)
    {
        UsuarioLogado = usuarioLogado;
    }

    public Usuario UsuarioLogado { get; }
    public Dictionary<int, NavegacaoGeral> Navegacoes
    {
        get
        {
            return new Dictionary<int, NavegacaoGeral>
            {
                { 1, new PaginaProdutos(UsuarioLogado)},
                { 2, new PaginaCarrinho(UsuarioLogado)}
            };
        }
    }

    public virtual void Executar() { Console.Clear(); }
    public void ExibirOpcoesDeNavegacao()
    {
        Console.Clear();
        Console.WriteLine(@" ______                 __                  ______  __           __     __                         
 /      \               |  \                /      \|  \         |  \   |  \                        
|  $$$$$$\ ______   ____| $$ ______        |  $$$$$$| $$ ______ _| $$_  | $$____   ______   _______ 
| $$   \$$/      \ /      $$/      \       | $$   \$| $$/      |   $$ \ | $$    \ /      \ /       \
| $$     |  $$$$$$|  $$$$$$|  $$$$$$\      | $$     | $|  $$$$$$\$$$$$$ | $$$$$$$|  $$$$$$|  $$$$$$$
| $$   __| $$  | $| $$  | $| $$    $$      | $$   __| $| $$  | $$| $$ __| $$  | $| $$    $$\$$    \ 
| $$__/  | $$__/ $| $$__| $| $$$$$$$$      | $$__/  | $| $$__/ $$| $$|  | $$  | $| $$$$$$$$_\$$$$$$\
 \$$    $$\$$    $$\$$    $$\$$     \       \$$    $| $$\$$    $$ \$$  $| $$  | $$\$$     |       $$
  \$$$$$$  \$$$$$$  \$$$$$$$ \$$$$$$$        \$$$$$$ \$$ \$$$$$$   \$$$$ \$$   \$$ \$$$$$$$\$$$$$$$ 
");
        Console.WriteLine($"Olá {UsuarioLogado.Nome}, Bem Vindo(a) a Code Clothes!\n");
        Console.WriteLine("1- Ver Produtos");
        Console.WriteLine("2- Meu Carrinho");
        Console.WriteLine("3- Meus Pedidos");
        Console.WriteLine("4- Sair");

        Console.Write("\nNavegar para: ");
        string? digitado = Console.ReadLine();
        int opcaoEscolhida = digitado == "" ? 0 : int.Parse(digitado!);

        if (Navegacoes.ContainsKey(opcaoEscolhida))
        {
            NavegacaoGeral navegacao = Navegacoes[opcaoEscolhida];
            navegacao.Executar();
        }
        else
        {
            Console.WriteLine("\nOpção Inválida!");
        }
    }
}
