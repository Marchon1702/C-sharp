using E_commerce_Loja_de_Roupas.Models;

namespace E_commerce_Loja_de_Roupas.Views.Pages;

internal class PaginaMeusPedidos : Pagina
{
    public PaginaMeusPedidos(Usuario usuarioLogado): base(usuarioLogado) { }
    protected Usuario DadosDoUsuario => UsuarioLogado;
    protected Carrinho CarrinhoDoUsuario => CarrinhoDoUsuario;

    public override void Executar()
    {
        base.Executar();
        ExibirTituloDaOpcao("Meus Pedidos");
        Console.WriteLine("-------------------Resumo-da-Compra------------------");
        foreach (Carrinho carrinhoFinalizado in DadosDoUsuario.PedidosFinalizados.Finalizados)
        {
            foreach(Produto produto in carrinhoFinalizado.Produtos)
            {
                Console.WriteLine(produto.Nome);
                Console.WriteLine(produto.Tamanho);
                Console.WriteLine(produto.QtdAhComprar);
                Console.WriteLine("------------------------------------");
            }
            Console.WriteLine($"\nTotal de Itens: {carrinhoFinalizado.QuantidadeTotal}");
            Console.WriteLine($"Valor Pago: {carrinhoFinalizado.TotalComFrete}");
            Console.WriteLine("Status: Em rota de entrega ->");
            Console.WriteLine("----------------------------------------------------");
        }

        Console.WriteLine("[-1] Voltar ao Menu Principal");
        Console.ReadKey();
        VoltarAoMenuPrincipal();
    }
}
