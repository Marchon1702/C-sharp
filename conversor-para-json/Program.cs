using System;
using System.IO;
using System.Text.Json;

class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Email { get; set; }
}

class Program
{
    static void Main()
    {
        // Criar uma instância de Pessoa e obter informações do usuário
        Pessoa pessoa = new Pessoa();
        Console.Write("Digite o nome: ");
        pessoa.Nome = Console.ReadLine();
        Console.Write("Digite a idade: ");
        pessoa.Idade = int.Parse(Console.ReadLine());
        Console.Write("Digite o e-mail: ");
        pessoa.Email = Console.ReadLine();

        // Serializar a pessoa em JSON
        string jsonString = JsonSerializer.Serialize(pessoa);

        // Nome do arquivo para salvar
        string fileName = "pessoa.json";

        // Escrever JSON no arquivo
        File.WriteAllText(fileName, jsonString);

        Console.WriteLine($"Os dados foram salvos em {fileName}");
        Console.WriteLine(Path.GetFullPath(fileName));
    }
}