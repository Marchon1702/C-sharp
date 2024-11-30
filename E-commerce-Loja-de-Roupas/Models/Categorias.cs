namespace E_commerce_Loja_de_Roupas.Models;

internal class Categoria
{
    public static IEnumerable<Produto> FiltrarPorCategoria(string categoria)
    {
        List<Produto> produtos = (List<Produto>)ProdutosGeral.RetornaTodoOsProdutos();
        return produtos.FindAll(prod => prod.Categoria.Equals(categoria));
    }
}


