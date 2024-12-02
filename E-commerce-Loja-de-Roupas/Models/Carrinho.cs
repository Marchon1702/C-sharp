namespace E_commerce_Loja_de_Roupas.Models;

internal class Carrinho
{
    public Carrinho(Usuario usuario)
    {
        DadosDoUsuario = usuario;
        _produtos = usuario.HistoricoDeProdutos;
    }

    public Usuario DadosDoUsuario { get; }
    private List<ProdutoPreAdquirido> _produtos;
    private int _total = 0;
    public IEnumerable<Produto> Produtos => _produtos;
    public int QuantidadeTotal => _total;

    public void AdicionarProduto(Produto novoProduto, int quantidade)
    {
        if (novoProduto.Estoque < quantidade)
        {
            Console.WriteLine("Estoque insuficiente!");
            return;
        }
        if (CalcularTotal()) _total += quantidade;
        if (!CalcularTotal())
        {
            _total -= quantidade;
            return;
        }
        else
        {
            _produtos.Add(novoProduto);
            novoProduto.Estoque += quantidade;
        }
    }

    public void RemoverProduto(Produto produto) 
    {
        if(produto.Estoque > 0)
        {
            produto.Estoque -= 1;
            return;
        }

        _produtos.Remove(produto);
        Console.WriteLine(produto.Estoque);
    } 

    private bool CalcularTotal()
    {
        if (QuantidadeTotal < 20) return true;

        Console.WriteLine("Carrinho cheio, Produto não adicionado :(");
        return false;
    }
}
