using CadastroProduto2.Dados;
using CadastroProduto2.Exibicao;
using CadastroProduto2.Modelos;
using CadastroProduto2.Servicos;
using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Chama o metodo ESTATICO Carregar para preencher a lista
            List<Produto> lista = OperacaoBancoDados.Carregar();

            Console.WriteLine("Itens carregados: " + lista.Count);


            // Imprime a lista
            ProdutoImprimir.Imprimir(lista);

            Console.ReadKey();
            /*
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
                int quantidade = int.Parse(Console.ReadLine());
                               
                // cria um objeto com todos os atributos da classe protudo
                Produto produto = new Produto(id, nome, preco, quantidade);

                // chama metodo para salvar o objeto na lista
                //produtoServico.Cadastro(produto);
                
                // salvo os dados da lista em JSON no arquivo 
                OperacaoBancoDados.Salvar(lista);
            }
            */
        }
    }
}