using E_commerce_Loja_de_Roupas.Models;
using E_commerce_Loja_de_Roupas.Views.Menus;


IEnumerable<Produto> camisas = Categoria.FiltrarPorCategoria("Camisas");
IEnumerable<Produto> casacos = Categoria.FiltrarPorCategoria("Casacos");
IEnumerable<Produto> shorts = Categoria.FiltrarPorCategoria("Shorts");
IEnumerable<Produto> calcas = Categoria.FiltrarPorCategoria("Calças");
IEnumerable<Produto> bones = Categoria.FiltrarPorCategoria("Bonés");



Menu menu = new Menu();
menu.MostrarLogo();
Menu menuLogin = new MenuLogin();
menuLogin.Executar();


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
