namespace E_commerce_Loja_de_Roupas.Models;

internal class Categoria
{
    public static IEnumerable<Produto> FiltrarPorCategoria(string categoria)
    {
        ProdutosGeral produtosGeral = new();
        List<Produto> produtos = produtosGeral.RetornaTodoOsProdutos().ToList();
        return produtos.FindAll(prod => prod.Categoria.Equals(categoria));
    }
}


