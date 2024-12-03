namespace E_commerce_Loja_de_Roupas.Models;

internal class Categoria
{
    public static IEnumerable<Produto> FiltrarPorCategoria(string categoria, IEnumerable<Produto> todosOsProdutos)
    {
        return todosOsProdutos.ToList().FindAll(prod => prod.Categoria.Equals(categoria));
    }
}


