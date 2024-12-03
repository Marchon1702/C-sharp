namespace E_commerce_Loja_de_Roupas.Models;
internal class Pagamento
{
    public Pagamento(Carrinho carrinhoDoCliente)
    {
        CarrinhoDoCliente = carrinhoDoCliente;
    }

    public Carrinho CarrinhoDoCliente { get; }
    public double Valor => CarrinhoDoCliente.PrecoTotal;

    //public void Pix() Essa funçÃo deve ser aplicada na PaginaPagamento
    //{
    //    Console.WriteLine("Realizar Pagamento para a chave Pix: code.clothes@gamil.com");
    //    Console.WriteLine("[1] Pagar Agora  [-1] Voltar ao Menu Principal");
    //    int opcaoEscolhida = int.Parse(Console.ReadLine()!);
    //    if (opcaoEscolhida == 1) Console.WriteLine("Obrigado Pela preferencia, volte sempre! :)");
    //    else VoltarAoMenuPrincipal();
    //}
}
