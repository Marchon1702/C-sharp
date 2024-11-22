Produto prod1 = new Produto();

prod1.nome = "Bola de Basquete";
prod1.marca = "Penalty";
prod1.AdicionaPreco(120);
prod1.AdicionaEstoque(2);

Console.WriteLine(prod1.DetalhesProduto);

Produto prod2 = new Produto();

prod2.nome = "Tênis";
prod2.marca = "Nike";
prod2.AdicionaPreco(245);
prod2.AdicionaEstoque(-1);

Console.WriteLine(prod2.DetalhesProduto);

