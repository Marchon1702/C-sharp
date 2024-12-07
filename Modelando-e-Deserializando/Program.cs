
//Modelar e desserializar a classe Filme, que pode ser encontrada no endpoint disponibilizado;

//Modelar e desserializar a classe Pais, que pode ser encontrada no endpoint disponibilizado;

//Modelar e desserializar a classe Carro, que pode ser encontrada no endpoint disponibilizado;

//Modelar e desserializar a classe Livro, que pode ser encontrada no endpoint disponibilizado;

using System.Text.Json;
using Modelando_e_Deserializando.Models;

using (HttpClient client = new HttpClient())
{
    try
    {
        string filmesJson = await client.GetStringAsync("https://raw.githubusercontent.com/ArthurOcFernandes/Exerc-cios-C-/curso-4-aula-2/Jsons/TopMovies.json");
        string paisesJson = await client.GetStringAsync("https://raw.githubusercontent.com/ArthurOcFernandes/Exerc-cios-C-/curso-4-aula-2/Jsons/Paises.json");
        string carrosJson = await client.GetStringAsync("https://raw.githubusercontent.com/ArthurOcFernandes/Exerc-cios-C-/curso-4-aula-2/Jsons/Carros.json");
        string livrosJson = await client.GetStringAsync("https://raw.githubusercontent.com/ArthurOcFernandes/Exerc-cios-C-/curso-4-aula-2/Jsons/Livros.json");

        var listaDeFilmes = JsonSerializer.Deserialize<List<Filme>>(filmesJson);
        var listaDePaises = JsonSerializer.Deserialize<List<Pais>>(paisesJson);
        var listaDeCarros = JsonSerializer.Deserialize<List<Carro>>(carrosJson);
        var listaDeLivros = JsonSerializer.Deserialize<List<Livro>>(livrosJson);

        foreach(Filme filme in listaDeFilmes!)
        {
            Console.WriteLine(filme.Nome);
        }

        foreach(Pais pais in listaDePaises!)
        {
            Console.WriteLine(pais.Nome);
        } 

        foreach(Carro carro in listaDeCarros!)
        {
            Console.WriteLine(carro.Marca);
        }

        foreach(Livro livro in listaDeLivros!)
        {
            Console.WriteLine(livro.Nome);
        }
    } 
    catch (Exception ex) 
    {
        Console.WriteLine("Requisição interrompida...");
        Console.WriteLine(ex.Message);
    }
}