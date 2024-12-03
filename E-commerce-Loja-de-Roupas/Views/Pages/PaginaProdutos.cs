﻿using E_commerce_Loja_de_Roupas.Models;

namespace E_commerce_Loja_de_Roupas.Views.Pages;

internal class PaginaProdutos : Pagina
{
    public PaginaProdutos(Usuario usuarioLogado) : base(usuarioLogado){}
    public Usuario DadosDoUsuario { get { return UsuarioLogado; } }

    public override void Executar()
    {
        base.Executar();
        ProdutosGeral produtosGeral = new ProdutosGeral();
        IEnumerable<Produto> todosOsProdutos = produtosGeral.RetornaTodoOsProdutos();
        Dictionary<int, IEnumerable<Produto>> produtosAhFiltrar = new Dictionary<int, IEnumerable<Produto>>
        {
            { 1, Categoria.FiltrarPorCategoria("Camisas")},
            { 3, Categoria.FiltrarPorCategoria("Casacos")},
            { 4, Categoria.FiltrarPorCategoria("Shorts")},
            { 5, Categoria.FiltrarPorCategoria("Calças")},
            { 6, Categoria.FiltrarPorCategoria("Bonés")},
            { 7, todosOsProdutos}
        }; 

        ExibirTituloDaOpcao("Catálogo Code Clothes \n");
        Console.WriteLine("Oque deseja ver? ");
        Console.WriteLine("[1] Camisas   [2] Casacos   [3] Shorts   [4] Calças   [5] Sapatos   [6] Bonés   [7] Todos \n");
        int opcaoEscolhida = int.Parse(Console.ReadLine()!);
        if (opcaoEscolhida < 1 || opcaoEscolhida > 7) VoltarAoMenuPrincipal();

        if (produtosAhFiltrar.ContainsKey(opcaoEscolhida)) 
        {
            IEnumerable<Produto> produtosFiltrados = produtosAhFiltrar[opcaoEscolhida];
            ExibirProdutosGeral(produtosFiltrados);
        }        
    }

    protected override void ExibirProduto(Produto produto, int posicaoNaTela)
    {
        base.ExibirProduto(produto, posicaoNaTela);
        Console.WriteLine("[1] Adicionar ao Carrinho ");
        Console.WriteLine("-------------------------------------------------------------------");
    }

    public void ExibirProdutosGeral(IEnumerable<Produto> produtosAhExibir)
    {
        Console.Clear();
        ExibirTituloDaOpcao("Catálogo Code Clothes\n");

        int keyProdutosCatalogo = 1;
        Dictionary<int, Produto> produtosDoCatalogo = new Dictionary<int, Produto>();

        foreach (Produto produto in produtosAhExibir)
        {
            ExibirProduto(produto, keyProdutosCatalogo);
            produtosDoCatalogo.Add(keyProdutosCatalogo++, produto);
        }

        if(DadosDoUsuario.Nome == "Convidado")
        {
            Console.WriteLine("\nFAÇA LOGIN PARA COMPRAS!");
            Console.ReadKey();
            VoltarAoMenuPrincipal();
        }

        Console.WriteLine("[Numero do Card] Selecionar Produto     [-1] Voltar para Menu Principal ");
        int opcaoEscolhida = int.Parse(Console.ReadLine()!);
        if (opcaoEscolhida == -1) VoltarAoMenuPrincipal();

        if (produtosDoCatalogo.ContainsKey(opcaoEscolhida))
        {
            Console.WriteLine($"\n\nProduto na posição {opcaoEscolhida} selecionado...");
            Console.WriteLine("[1] Adicionar ao Carrinho  \n");
            int? acaoEscolhida = int.Parse(Console.ReadLine()!);
            if (acaoEscolhida == null || acaoEscolhida < 1 || acaoEscolhida > 3) VoltarAoMenuPrincipal();
            Produto produtoAhAlterar = produtosDoCatalogo[opcaoEscolhida];

            switch (acaoEscolhida)
            {
                case 1:
                    VoltarAoMenuPrincipal(); // Fazer Logica de adicionar ao Carrinho
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    VoltarAoMenuPrincipal();
                    break;
            }
        }
    }
}
