using E_commerce_Loja_de_Roupas.Models;

namespace E_commerce_Loja_de_Roupas.Views.Pages;

internal class PaginaPagamento : Pagina
{
    public PaginaPagamento(Usuario usuarioLogado) : base(usuarioLogado) {}
    protected Usuario DadosDoUsuario => UsuarioLogado;
    protected Carrinho CarrinhoDoUsuario => DadosDoUsuario.CarrinhoDoUsuario;

    public double TotalAhPagar { get; private set; }

    public override void Executar()
    {
        base.Executar();
        ExibirTituloDaOpcao("Pagina de Pagamento");

        Console.WriteLine("-------------------Resumo-da-Compra------------------");
        foreach (Produto produto in CarrinhoDoUsuario.Produtos)
        {
            Console.WriteLine(produto.Nome);
        }
        Console.WriteLine($"\nTotal de Itens: {CarrinhoDoUsuario.QuantidadeTotal}");
        Console.WriteLine($"Subtotal: {CarrinhoDoUsuario.PrecoSubtotal}");
        double frete = new Random().Next(11, 31);
        TotalAhPagar = CarrinhoDoUsuario.PrecoSubtotal >= 300 ? CarrinhoDoUsuario.PrecoSubtotal : CarrinhoDoUsuario.PrecoSubtotal + frete;
        CarrinhoDoUsuario.CapturaTotalComFrete(TotalAhPagar);
        if (TotalAhPagar == CarrinhoDoUsuario.PrecoSubtotal) Console.WriteLine("Cupom de Frete Grátis Adicionado!");
        Console.WriteLine($"Total a Pagar: {TotalAhPagar}");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("\n [1] Pagar Agora         [-1] Voltar ao Menu Principal");

        int opcaoEscolhida = int.Parse( Console.ReadLine()!);
        if (opcaoEscolhida == 1)
        {
            Console.WriteLine("Selecione a forma de Pagamento...\n");
            Console.WriteLine("[1] Pix   [2] Cartão de Crédito");
            int opcaoDePagammento = int.Parse(Console.ReadLine()!);
            switch (opcaoDePagammento)
            {
                case 1:
                    ConfirmarPgComPix();
                    break;
                case 2: 
                    ConfirmarPgCredito();
                    break;
                default: VoltarAoMenuPrincipal();
                    break;
            }
        }
        else VoltarAoMenuPrincipal();
    }

    private void ConfirmarPgComPix()
    {
        Console.WriteLine("Chave Pix: code.clothes@gmail.com");
        Console.WriteLine("Pressione Enter para confirmar...\n");
        Console.ReadKey();
        Carrinho carrinhoFinalizado = new Carrinho(CarrinhoDoUsuario.Produtos.ToList());
        carrinhoFinalizado.CapturaTotalComFrete(TotalAhPagar);
        DadosDoUsuario.PedidosFinalizados.FinalizarPedido(carrinhoFinalizado);
        Console.WriteLine("Pedido Confirmado, Volte Sempre :)");
        Thread.Sleep(3000);
        CarrinhoDoUsuario.ResetarCarrinho();
        VoltarAoMenuPrincipal();
    }

    private void ConfirmarPgCredito()
    {
        Console.WriteLine("Insira os dados do seu Cartão abaixo: \n");
        Console.Write("Número impresso: \n");
        string numCartao = Console.ReadLine()!;
        if(numCartao.Length != 16 && numCartao.Length != 15)
        {
            Console.WriteLine(numCartao.Length);
            Console.WriteLine("Cartão Inválido :(");
            VoltarAoMenuPrincipal();
        }
        Console.Write("Titular do Cartão: ");
        string nomeTitular = Console.ReadLine()!;
        Console.WriteLine("Código de Segurança: ");
        int codSegurança = int.Parse(Console.ReadLine()!);
        if(codSegurança < 100 && codSegurança > 999)
        {
            Console.WriteLine("Código Inválido!");
            VoltarAoMenuPrincipal();
        }

        Carrinho carrinhoFinalizado = new Carrinho(CarrinhoDoUsuario.Produtos.ToList());
        carrinhoFinalizado.CapturaTotalComFrete(TotalAhPagar);
        Console.WriteLine("\nPedido Confirmado, Volte Sempre :)");
        Thread.Sleep(3000);
        CarrinhoDoUsuario.ResetarCarrinho();
        VoltarAoMenuPrincipal();
    }
}
