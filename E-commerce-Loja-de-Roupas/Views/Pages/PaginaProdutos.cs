using E_commerce_Loja_de_Roupas.Models;

namespace E_commerce_Loja_de_Roupas.Views.Pages;

internal class PaginaProdutos : Pagina
{
    public PaginaProdutos(Usuario usuarioLogado) : base(usuarioLogado){}
    public Usuario DadosDoUsuario { get { return UsuarioLogado; } }
    //Para verificar se usuario é valido acesso o Nome dele, ser for "Convidado" ele não é um usuario valido.

    public override void Executar()
    {
        base.Executar();
        Console.WriteLine("Bem vindo a página produto!");
    }
}
