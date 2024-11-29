namespace E_commerce_Loja_de_Roupas.Models;

internal class Categoria(List<Produto> todosOsProdutos)
{
    public Dictionary<string, List<Produto>> FiltrarPorCategoria(string categoria)
    {
        List<Produto> porCategoriaLista = todosOsProdutos.FindAll(prod => prod.Categoria.Equals(categoria));
        Dictionary<string, List<Produto>> porCategoria = new();
        porCategoria.Add(categoria, porCategoriaLista);
        return porCategoria;
    }
}
