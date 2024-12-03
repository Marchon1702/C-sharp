using E_commerce_Loja_de_Roupas.Models;

namespace E_commerce_Loja_de_Roupas.Views.Pages;

internal class PaginaCarrinho : Pagina
{
    public PaginaCarrinho(Usuario usuarioLogado) : base(usuarioLogado) { }
    public Usuario DadosDoUsuario { get { return UsuarioLogado; } }

    public override void Executar()
    {
        base.Executar();
        ExibirTituloDaOpcao($"Carrinho de: {DadosDoUsuario.Nome}");

        Carrinho carrinhoDoUsuario = new(DadosDoUsuario);
        int keyProdutosCarrinho = 1;
        Dictionary<int, Produto> produtosDoCarrinho = new Dictionary<int, Produto>();

        foreach(Produto produto in carrinhoDoUsuario.Produtos)
        {
            ExibirProduto(produto, keyProdutosCarrinho);
            produtosDoCarrinho.Add(keyProdutosCarrinho++ , produto);
        }

        int totalProdutos = DadosDoUsuario.HistoricoDeProdutos.Sum(prod => prod.QtdAhComprar);
        Console.WriteLine($"\nTotal de Produtos: {totalProdutos}");

        double totalPreco = DadosDoUsuario.HistoricoDeProdutos.Sum(prod => prod.Preco);
        Console.WriteLine($"\nTotal da Compra: {Math.Round(totalPreco, 2)}\n");

        Console.WriteLine("[Numero do Card] Selecionar Produto     [-1] Voltar para Menu Principal ");
        int opcaoEscolhida = int.Parse(Console.ReadLine()!);
        if ( opcaoEscolhida == -1) VoltarAoMenuPrincipal();
      
        if(produtosDoCarrinho.ContainsKey(opcaoEscolhida)) 
        {
            Console.WriteLine($"\n\nProduto na posição {opcaoEscolhida} selecionado...");
            Console.WriteLine("[1] Add ++    [2] Reduzir --      [3]Remover :( \n");
            int? acaoEscolhida = int.Parse(Console.ReadLine()!);
            if (acaoEscolhida == null || acaoEscolhida < 1 || acaoEscolhida > 3) VoltarAoMenuPrincipal();
            Produto produtoAhAlterar = produtosDoCarrinho[opcaoEscolhida];

            switch (acaoEscolhida)
            {
                case 1:
                    carrinhoDoUsuario.AdicionarQuantidade(produtoAhAlterar, totalPreco);
                    ExibirProduto(produtoAhAlterar, opcaoEscolhida);
                    VoltarAoMenuPrincipal();
                    break;
                case 2:
                    carrinhoDoUsuario.ReduzirQuantidade(produtoAhAlterar, totalPreco);
                    ExibirProduto(produtoAhAlterar, opcaoEscolhida);
                    VoltarAoMenuPrincipal();
                    break;
                case 3:
                    carrinhoDoUsuario.RemoverProduto(produtoAhAlterar, totalPreco);
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
        Produto produtoAtual = DadosDoUsuario.HistoricoDeProdutos.Find(prod => prod.Id.Equals(produto.Id));       
        Console.WriteLine($"Qtd Unidade: {produtoAtual?.QtdAhComprar ?? 0}\n\n");
        Console.WriteLine("[1] Adicionar Unidade  [2] Remover Unidade  [3] Remover Produto");
        Console.WriteLine("-------------------------------------------------------------------");
    }
}
