using E_commerce_Loja_de_Roupas.Models;

namespace E_commerce_Loja_de_Roupas.Views.Pages;

internal class PaginaCarrinho : Pagina
{
    public PaginaCarrinho(Usuario usuarioLogado) : base(usuarioLogado) { }
    protected Usuario DadosDoUsuario { get { return UsuarioLogado; } }

    public override void Executar()
    {
        base.Executar();
        ExibirTituloDaOpcao($"Carrinho de: {DadosDoUsuario.Nome}");

        Carrinho carrinhoDoUsuario = DadosDoUsuario.CarrinhoDoUsuario;
        int keyProdutosCarrinho = 1;
        Dictionary<int, Produto> produtosDoCarrinho = new Dictionary<int, Produto>();

        foreach(Produto produto in carrinhoDoUsuario.Produtos)
        {
            ExibirProduto(produto, keyProdutosCarrinho);
            produtosDoCarrinho.Add(keyProdutosCarrinho++ , produto);
        }

        Console.WriteLine($"\nTotal de Produtos: {carrinhoDoUsuario.QuantidadeTotal}");

        Console.WriteLine($"\nSubtotal: {carrinhoDoUsuario.PrecoSubtotal}\n");

        Console.WriteLine("[Numero do Card] Selecionar Produto   [-2] Finalizar Pedido   [-1] Voltar para Menu Principal ");
        int opcaoEscolhida = int.Parse(Console.ReadLine()!);
        switch(opcaoEscolhida)
        {
            case -1: VoltarAoMenuPrincipal();
                break;
            case -2:
                if (DadosDoUsuario.CarrinhoDoUsuario.QuantidadeTotal == 0) VoltarAoMenuPrincipal();
                else Navegacoes[-2].Executar();
                break;
            default: break; 
        }
       
        if (produtosDoCarrinho.ContainsKey(opcaoEscolhida)) 
        {
            Console.WriteLine($"\n\nProduto na posição {opcaoEscolhida} selecionado...");
            Console.WriteLine("[1] Add ++    [2] Reduzir --      [3]Remover :( \n");
            int? acaoEscolhida = int.Parse(Console.ReadLine()!);
            if (acaoEscolhida == null || acaoEscolhida < 1 || acaoEscolhida > 3) VoltarAoMenuPrincipal();
            Produto produtoAhAlterar = produtosDoCarrinho[opcaoEscolhida];

            switch (acaoEscolhida)
            {
                case 1:
                    carrinhoDoUsuario.AdicionarQuantidade(produtoAhAlterar);
                    ExibirProduto(produtoAhAlterar, opcaoEscolhida);
                    VoltarAoMenuPrincipal();
                    break;
                case 2:
                    carrinhoDoUsuario.ReduzirQuantidade(produtoAhAlterar);
                    ExibirProduto(produtoAhAlterar, opcaoEscolhida);
                    VoltarAoMenuPrincipal();
                    break;
                case 3:
                    carrinhoDoUsuario.RemoverProduto(produtoAhAlterar);
                    ExibirProduto(produtoAhAlterar, opcaoEscolhida);
                    VoltarAoMenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    VoltarAoMenuPrincipal();
                    break;
            }
        }
    }

    protected override void ExibirProduto(Produto produto, int posicaoNaTela)
    {
        base.ExibirProduto(produto, posicaoNaTela);
        Produto produtoAtual = DadosDoUsuario.CarrinhoDoUsuario.Produtos.ToList().Find(prod => prod.Id.Equals(produto.Id));       
        Console.WriteLine($"Qtd Unidade: {produtoAtual?.QtdAhComprar ?? 0}\n\n");
        Console.WriteLine("[1] Adicionar Unidade  [2] Remover Unidade  [3] Remover Produto");
        Console.WriteLine("-------------------------------------------------------------------");
    }
}
