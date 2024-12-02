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

        Console.WriteLine($"\nTotal de Produtos: {DadosDoUsuario.HistoricoDeProdutos.Count}\n");

        Console.WriteLine("[Numero do Card] Selecionar Produto     [-1] Voltar para Menu Principal ");
        int opcaoEscolhida = int.Parse(Console.ReadLine()!);
        if ( opcaoEscolhida == -1) VoltarAoMenuPrincipal();
      
        if(produtosDoCarrinho.ContainsKey(opcaoEscolhida)) 
        {
            Console.WriteLine($"\n\nProduto na posição {opcaoEscolhida} selecionado...");
            Console.WriteLine("[1] Add ++         [2] Remove -- \n");
            int? acaoEscolhida = int.Parse(Console.ReadLine()!);
            if (acaoEscolhida == null || acaoEscolhida < 1 || acaoEscolhida > 2) return;
            Produto produtoAhAlterar = produtosDoCarrinho[opcaoEscolhida];

            switch (acaoEscolhida)
            {
                case 1:
                    carrinhoDoUsuario.AdicionarProduto(produtoAhAlterar, 1);
                    Console.Clear();
                    ExibirProduto(produtoAhAlterar, opcaoEscolhida);
                    VoltarAoMenuPrincipal();
                    break;
                case 2:
                    carrinhoDoUsuario.RemoverProduto(produtoAhAlterar);
                    Console.Clear();
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
        // Localizar a quantidade de unidades a serem compradas no carrinho e o valor total.
        base.ExibirProduto(produto, posicaoNaTela);
        int qtd = 0;
        foreach(ProdutoPreAdquirido prod in DadosDoUsuario.HistoricoDeProdutos)
        {
            //if(prod.Nome.Equals(produto.Nome)) qtd = ;
        }
        Console.WriteLine($"Qtd Unidade: {}\n\n");
        Console.WriteLine("[1] Adicionar Unidade    [2] Remover Unidade");
        Console.WriteLine("-------------------------------------------------");
    }
}
