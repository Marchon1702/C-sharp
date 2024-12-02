using E_commerce_Loja_de_Roupas.Models;

namespace E_commerce_Loja_de_Roupas.Views.Pages;

internal class Pagina : NavegacaoGeral
{
    public Pagina(Usuario usuarioLogado) : base(usuarioLogado) { }

    protected void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }

    protected void VoltarAoMenuPrincipal()
    {
        Console.WriteLine("[-1] Menu Principal");
        Console.ReadKey();
        ExibirOpcoesDeNavegacao();
    }

    protected virtual void ExibirProduto(Produto produto, int posicaoNaTela)
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine($"                                  Selecionar: [{posicaoNaTela}]\n");
        Console.WriteLine(produto.Nome);
        Console.WriteLine($"Categoria: {produto.Categoria}");
        Console.WriteLine($"Descrição: {produto.Descricao}");
        Console.WriteLine($"Tamanho: {produto.Tamanho}");
        Console.WriteLine($"\nPreco: {produto.Preco}\n");
    }
}