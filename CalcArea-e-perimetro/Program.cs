// Criar uma hierarquia de classes representando formas geométricas, como Quadrado, Círculo e Triângulo. Utilize herança para criar uma classe base chamada FormaGeometrica, que contenha métodos para calcular a área e o perímetro de uma forma.

using CalcArea_e_perimetro.Models;

Console.WriteLine("Area e Perímetro de: ");
FormaGeometrica quadrado = new Quadrado();
Console.WriteLine($"Quadrado Área = {quadrado.CalculaArea(5, 5)} Perímetro = {quadrado.CalculaPerimetro(4)}");

FormaGeometrica triangulo = new Triangulo();
Console.WriteLine($"Triângulo Área = {triangulo.CalculaArea(8, 16)} Perímetro = {triangulo.CalculaPerimetro(3)}");

FormaGeometrica circulo = new Circulo();
Console.WriteLine($"Circulo Área = {circulo.CalculaArea(60, 0)} Perímetro = {circulo.CalculaPerimetro(60)}");
