namespace E_commerce_Loja_de_Roupas.Models;

internal class Carrinho
{
    private List<Produto> _produtos = new();
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
            novoProduto.Estoque -= quantidade;
        } 
    }

    public void RemoverProduto(Produto produto) => _produtos.Remove(produto);

    private bool CalcularTotal()
    {
        if (QuantidadeTotal < 20) return true;
       
        Console.WriteLine("Carrinho cheio, Produto não adicionado :(");
        return false;
    }
}
