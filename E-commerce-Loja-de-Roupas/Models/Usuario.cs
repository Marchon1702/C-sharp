namespace E_commerce_Loja_de_Roupas.Models;

internal class Usuario
{
    public Usuario(string nome, string senha, string endereco, List<Produto> historicoDeProdutos)
    {
        Nome = nome;
        Senha = senha;
        Endereco = endereco;
        CarrinhoDoUsuario = new Carrinho(historicoDeProdutos);
        PedidosFinalizados = new PedidosFinalizados(CarrinhoDoUsuario);
    }

    public Guid Id { get; } = Guid.NewGuid();
    public string Nome { get; }
    public string Senha { get; }
    public string Endereco { get; }
    public Carrinho CarrinhoDoUsuario { get; } 
    public PedidosFinalizados PedidosFinalizados { get; }
}
