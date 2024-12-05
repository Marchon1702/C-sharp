namespace E_commerce_Loja_de_Roupas.Models;
internal class PedidosFinalizados
{
    public PedidosFinalizados(Carrinho carrinhoDoUsuario) 
    {
        CarrinhoDoUsuario = carrinhoDoUsuario;
        Finalizados = new();
    }
    public Carrinho CarrinhoDoUsuario { get; }
    public List<Carrinho> Finalizados { get; private set; }

    public void FinalizarPedido(Carrinho carrinhoAhFinalizar) => Finalizados.Add(carrinhoAhFinalizar);
}
