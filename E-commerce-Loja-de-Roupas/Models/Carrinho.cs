namespace E_commerce_Loja_de_Roupas.Models;

internal class Carrinho
{
    public Carrinho(Usuario usuario)
    {
        DadosDoUsuario = usuario;
        _produtos = usuario.HistoricoDeProdutos;
    }

    public Usuario DadosDoUsuario { get; }
    private List<Produto> _produtos;
    private int _total = 0;
    public IEnumerable<Produto> Produtos => _produtos;
    public int QuantidadeTotal => _total;

    public void AdicionarProduto(Produto novoProduto, int quantidade) // Só será chamado na página ver Produtos.
    {
        if (quantidade < 1) { Console.WriteLine("Quantidade inválida :("); return; }
        if (novoProduto.Estoque < quantidade)
        {
            Console.WriteLine("-----------------------------ATENÇÃO-----------------------------");
            Console.WriteLine("\nEstoque insuficiente!\n");
            return;
        }
        if (CalcularTotalItens()) _total += quantidade;
        if (!CalcularTotalItens())
        {
            _total -= quantidade;
            return;
        }

        novoProduto.QtdAhComprar = quantidade;
        _produtos.Add(novoProduto);
    }

    public void RemoverProduto(Produto produto, double totalPreco) 
    {
        produto.Estoque += produto.QtdAhComprar; // Falta ajustar a lógica de totalPreco em todos os métodos.
        totalPreco -= produto.Preco;
        _produtos.Remove(produto);
    }  // Será chamado na paginacarrinho


    public void AdicionarQuantidade(Produto produto, double totalPreco) 
    {
        if (produto.Estoque < produto.QtdAhComprar) 
        {
            Console.Clear();
            Console.WriteLine("-----------------------------ATENÇÃO-----------------------------");
            Console.WriteLine($"Estoque Esgotado! :(");
            Console.WriteLine("\nVocê já adicionou o máximo de unidades! :)\n");
            return;
        }

        Console.Clear ();
        totalPreco += produto.Preco;
        produto.QtdAhComprar++;
        produto.Estoque--;
    } 

    public void ReduzirQuantidade(Produto produto, double totalPreco)
    {
        if(produto.QtdAhComprar == 1)
        {
            Console.Clear();
            RemoverProduto(produto, totalPreco);
            return;
        }
        Console.Clear();
        totalPreco -= produto.Preco;
        produto.QtdAhComprar--;
        produto.Estoque++;
    }
  
    private bool CalcularTotalItens()
    {
        if (QuantidadeTotal < 20) return true;
        Console.WriteLine("-----------------------------ATENÇÃO-----------------------------");
        Console.WriteLine("Carrinho cheio, Produto não adicionado :(");
        return false;
    }
}
