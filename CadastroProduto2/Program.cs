using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite SIM ou NAO para cadastrar novos produtos: ");
            string simOuNao = Console.ReadLine();

            if (simOuNao == "sim")
            {
                Console.Write("Digite o ID do produto: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Digite o NOME do Produto: ");
                string nome = Console.ReadLine();
                Console.Write("Digite o PRECO do produto: ");
                double preco = double.Parse(Console.ReadLine());
                Console.Write("Digite a QUANTIDADE do produto: ");
            }        
        }
    }
}