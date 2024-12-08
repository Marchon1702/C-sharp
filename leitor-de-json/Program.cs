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
        // Nome do arquivo para ler
        string fileName = @"C:\Users\Matheus\source\repos\C-sharp\conversor-para-json\bin\Debug\net8.0\pessoa.json";

        // Verificar se o arquivo existe
        if (File.Exists(fileName))
        {
            // Ler conteúdo do arquivo JSON
            string jsonString = File.ReadAllText(fileName);

            // Desserializar JSON para objeto Pessoa
            Pessoa pessoa = JsonSerializer.Deserialize<Pessoa>(jsonString);

            // Exibir informações da pessoa
            Console.WriteLine($"Nome: {pessoa.Nome}");
            Console.WriteLine($"Idade: {pessoa.Idade}");
            Console.WriteLine($"E-mail: {pessoa.Email}");
        }
        else
        {
            Console.WriteLine($"O arquivo {fileName} não existe.");
        }
    }
}