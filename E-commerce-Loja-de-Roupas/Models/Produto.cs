namespace E_commerce_Loja_de_Roupas.Models;

internal class Produto
{
    private int _estoqueAhValidar;

    public Produto(
       string nome,
       string descricao,
       double preco,
       string categoria,
       string tamanho,
       int estoque)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        Categoria = categoria;
        Tamanho = tamanho;
        Estoque = estoque; // Aqui ativa a lógica do setter
    }

    public Guid Id { get; }
    public string Nome { get; }
    public string Descricao { get; }
    public double Preco { get; set; }
    public string Categoria { get; }
    public string Tamanho { get; }

    public int Estoque
    {
        get { return _estoqueAhValidar; }
        set
        {
            _estoqueAhValidar = value < 0 ? 0 : value;
        }
    }

    // A lógica do set é ativada quando a propriedade Estoque recebe um valor de alguma forma, no caso dessa classe, Estoque recebe o valor do parâmtro estoque.
    // O get é ativado do lado de fora, quando a prop da instância é acessada.

    public bool VerificarDisponibilidade() => Estoque > 0;

    public void AtualizarEstoque(int novaQuantidade)
    {
        Estoque = novaQuantidade > 0 ? novaQuantidade : 0;
    }
}
