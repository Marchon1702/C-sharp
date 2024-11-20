// Escrever uma função que a partir de dois números de ponto flutuante a e b
// exiba no console o resultado de suas quatro operações básicas
// (adição, subtração, divisão e multiplicação), utilizando interpolação de strings.


 void CalculaAe(float a, float b)
{
    Console.WriteLine($"{a} + {b} = {a + b}");
    Console.WriteLine($"{a} - {b} = {a - b}");
    Console.WriteLine($"{a} x {b} = {a * b}");
    Console.WriteLine($"{a} / {b} = {a / b}");
}

CalculaAe(4, 5);