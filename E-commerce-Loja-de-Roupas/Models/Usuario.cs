namespace E_commerce_Loja_de_Roupas.Models;

internal class Usuario
{
    public Usuario(string nome, string senha, string endereco, List<ProdutoPreAdquirido> historicoDeProdutos)
    {
        Nome = nome;
        Senha = senha;
        Endereco = endereco;
        HistoricoDeProdutos = historicoDeProdutos;
    }

    public Guid Id { get; } = Guid.NewGuid();
    public string Nome { get; }
    public string Senha { get; }
    public string Endereco { get; }
    public List<ProdutoPreAdquirido> HistoricoDeProdutos { get; }
}
