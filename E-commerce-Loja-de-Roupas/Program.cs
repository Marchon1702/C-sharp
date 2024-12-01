using E_commerce_Loja_de_Roupas.Models;
using E_commerce_Loja_de_Roupas.Views.Menus;
using E_commerce_Loja_de_Roupas.Views.Pages;

IEnumerable<Produto> camisas = Categoria.FiltrarPorCategoria("Camisas");
IEnumerable<Produto> casacos = Categoria.FiltrarPorCategoria("Casacos");
IEnumerable<Produto> shorts = Categoria.FiltrarPorCategoria("Shorts");
IEnumerable<Produto> calcas = Categoria.FiltrarPorCategoria("Calças");
IEnumerable<Produto> bones = Categoria.FiltrarPorCategoria("Bonés");

Dictionary<int, Pagina> navegacoes = new Dictionary<int, Pagina>
{
    { 1, new PaginaProdutos()}
};
MenuLogin menuLogin = new MenuLogin();

void ExibirOpcoesDeNavegacao()
{
    Console.Clear();
    menuLogin.MostrarLogo();
    Console.WriteLine("1- Ver Produtos");
    Console.WriteLine("3- Meu Carrinho");
    Console.WriteLine("4- Meus Pedidos");
    Console.WriteLine("5- Sair");

    Console.Write("\nNavegar para: ");
    string? digitado = Console.ReadLine();
    int opcaoEscolhida = digitado == "" ? 0 : int.Parse(digitado!);

    if (navegacoes.ContainsKey(opcaoEscolhida))
    {
        Pagina navegacao = navegacoes[opcaoEscolhida];
        navegacao.Executar();
    }
    else
    {
        Console.WriteLine("\nOpção Inválida!");
    }
}

menuLogin.MostrarLogo();
menuLogin.Executar();
if(menuLogin.Liberado) ExibirOpcoesDeNavegacao();
else
{
    PaginaProdutos paginaDeProdutos = new();
    paginaDeProdutos.Executar();
}


//if (menuLogin.Liberado) 
//{ 

//}










//Console.WriteLine("Registre um produto");
//Console.Write("Nome: ");
//string nomeProduto = Console.ReadLine()!;
//Console.Write("Descrição breve: ");
//string descProduto = Console.ReadLine()!;
//Console.Write("Preço: ");
//double precoProduto = double.Parse(Console.ReadLine()!);
//Console.Write("Categoria: ");
//string catProduto = Console.ReadLine()!;
//Console.Write("Tamanho: ");
//string tamanhoProduto = Console.ReadLine()!;
//Console.Write("Estoque: ");
//int estoqueProduto = int.Parse(Console.ReadLine()!);

//Produto camisa = new(nomeProduto, descProduto, precoProduto, catProduto, tamanhoProduto, estoqueProduto);

//Carrinho carrinho = new Carrinho();
//carrinho.AdicionarProduto(camisa, 2);
//foreach(Produto prod in carrinho.Produtos)
//{
//    Console.WriteLine(prod.Nome);
//    Console.WriteLine(prod.Descricao);
//    Console.WriteLine(prod.Preco);
//    Console.WriteLine(prod.Categoria);
//    Console.WriteLine(prod.Tamanho);
//    Console.WriteLine(prod.Estoque);
//}
