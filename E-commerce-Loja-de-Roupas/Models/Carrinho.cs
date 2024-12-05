namespace E_commerce_Loja_de_Roupas.Models;

internal class Carrinho
{
    public Carrinho(List<Produto> produtosDoUsuario)
    {
        _produtos = produtosDoUsuario;
    }

    private List<Produto> _produtos;
    public IEnumerable<Produto> Produtos => _produtos;
    public int QuantidadeTotal => Produtos.Sum(prod => prod.QtdAhComprar);
    public double PrecoSubtotal { get 
        {
            List<double> listaDePrecos = new List<double>();

            foreach(Produto produto in _produtos)
            {
                listaDePrecos.Add(produto.Preco * produto.QtdAhComprar);
            } 

            return Math.Round(listaDePrecos.Sum(), 2);
        } 
    }
    public double TotalComFrete { get; private set; } 

    public void AdicionarProduto(Produto novoProduto) 
    {
        bool jaAdicionado = _produtos.Any(prod => prod.Id.Equals(novoProduto.Id));
        if(jaAdicionado)
        {
            Produto produtoExistente = _produtos.Find(prod => prod.Id.Equals(novoProduto.Id));
            produtoExistente!.QtdAhComprar++;
            Console.WriteLine($"Qtd adicionada {novoProduto.Id} == {produtoExistente.Id}");
            return;
        }
        
        if (novoProduto.Estoque == 0)
        {
            Console.WriteLine("-----------------------------ATENÇÃO-----------------------------");
            Console.WriteLine("\nEstoque insuficiente!\n");
            return;
        }
        if (!CalcularTotalItens()) return;

        novoProduto.QtdAhComprar++ ;
        _produtos.Add(novoProduto);
    }

    public void RemoverProduto(Produto produto) 
    {
        produto.Estoque += produto.QtdAhComprar;
        produto.QtdAhComprar = 0;
        _produtos.Remove(produto);
    } 

    public void AdicionarQuantidade(Produto produto) 
    {
        if (produto.Estoque == 0) 
        {
            Console.Clear();
            Console.WriteLine("-----------------------------ATENÇÃO-----------------------------");
            Console.WriteLine($"Estoque Esgotado! :(");
            Console.WriteLine("\nVocê já adicionou o máximo de unidades! :)\n");
            return;
        }
        if (!CalcularTotalItens()) return;

        Console.Clear ();
        produto.QtdAhComprar++;
        produto.Estoque--;
    } 

    public void ReduzirQuantidade(Produto produto)
    {
        if(produto.QtdAhComprar == 1)
        {
            Console.Clear();
            RemoverProduto(produto);
            return;
        }
        Console.Clear();
        produto.QtdAhComprar--;
        produto.Estoque++;
    }

    public void CapturaTotalComFrete(double totalAhPagar) => TotalComFrete = totalAhPagar;

    public void ResetarCarrinho() => _produtos.Clear();
  
    private bool CalcularTotalItens()
    {
        if (QuantidadeTotal < 20) return true;
        Console.WriteLine("-----------------------------ATENÇÃO-----------------------------");
        Console.WriteLine("Carrinho cheio, Produto não adicionado :(");
        return false;
    }
}
