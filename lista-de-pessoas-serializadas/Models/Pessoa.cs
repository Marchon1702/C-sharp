using System.Text.Json;

namespace lista_de_pessoas_serializadas.Models;

internal class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Email { get; set; }

    public static void SerializarRegistros(List<Pessoa> pessoas)
    {
        string json = JsonSerializer.Serialize(pessoas);
        Console.WriteLine(pessoas);

        string fileName = "lista-de-pessoas.json";

        File.WriteAllText(fileName, json);
        Console.WriteLine($"Json salvo em: {Path.GetFullPath(fileName)}");
    }

    public static List<Pessoa> DeserializaRegistros(string filename)
    {  
        if(File.Exists(filename))
        {
            string jsonString = File.ReadAllText(filename);
            List<Pessoa> listaDePessoas = JsonSerializer.Deserialize<List<Pessoa>>(jsonString)!;
            
            foreach(Pessoa pessoa in listaDePessoas)
            {
                Console.WriteLine(pessoa.Nome);
                Console.WriteLine(pessoa.Idade);
                Console.WriteLine(pessoa.Email);
                Console.WriteLine("-----------------------------");
            }
            return listaDePessoas;
        } else
        {
            Console.WriteLine("Arquivo não encontrado!");
            return new List<Pessoa>();
        }
    }

    public static void FiltrarPorIdade(List<Pessoa> pessoas, int idade)
    {
        List<Pessoa> pessoasPorIdade = pessoas.Where(pessoa => pessoa.Idade == idade).ToList();
        if(pessoasPorIdade.Count > 0)
        {
            foreach(Pessoa pessoa in pessoasPorIdade)
            {
                Console.WriteLine(pessoa.Nome);
                Console.WriteLine(pessoa.Idade);
                Console.WriteLine(pessoa.Email);
                Console.WriteLine("-----------------------------");
            }
        } else
        {
            Console.WriteLine("Essa lista não possui pessoas da idade solicitada!");
        }
    }
}


