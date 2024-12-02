namespace E_commerce_Loja_de_Roupas.Models;

internal class ProdutoPreAdquirido : Produto
{
    public ProdutoPreAdquirido(string nome, string descricao, double preco, string categoria, string tamanho, int estoque, int qtdAhComprar) : base(nome, descricao, preco, categoria, tamanho, estoque)
    { QtdAhComprar = 0; }

    public int QtdAhComprar { get; private set; }
    public double PrecoTotal => QtdAhComprar * Preco;
}
