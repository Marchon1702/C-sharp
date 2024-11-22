// Desenvolver a classe Produto, com os atributos nome, marca, preco e estoque. Além disso, garantir que o preço e o estoque do produto sejam valores positivos e criar uma propriedade que mostra detalhadamente as informações do produto, para que seja usado pela equipe de vendas.

class Produto
{
    public string nome;
    public string marca;
    private int preco;
    private int estoque;
    public string DetalhesProduto => 
        $@"
----{nome}-{marca}----
Preço: {preco}
Estoque: {estoque}
----------------------
";

    public void AdicionaPreco(int preco)
    {
        if(preco >= 0)
        {
            this.preco = preco;
            Console.WriteLine($"Valor: {preco} adicionado a atributo preco!");
        } else
        {
            this.preco = 0;
            Console.WriteLine($"Valor {preco} não é válido, preco recebeu 0!");
        }       
    }

    public void AdicionaEstoque(int estoque)
    {
        if (estoque >= 0)
        {
           this.estoque = estoque;
            Console.WriteLine($"Valor: {estoque} adicionado a atributo estoque!");
        } else
        {
            this.estoque = 0;
            Console.WriteLine($"Valor {estoque} não é válido, estoque recebeu 0!");
        }
    }
}