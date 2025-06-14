using CadastroProduto2.Dados;
using CadastroProduto2.Exibicao;
using CadastroProduto2.Modelos;
using CadastroProduto2.Servicos;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

            // Chama o metodo ESTATICO Carregar para preencher a lista
            List<Produto> listaDeProdutos = OperacaoBancoDados.Carregar();

            // Imprime a quantidade de objetos na lista
            Console.WriteLine("Itens carregados: " + listaDeProdutos.Count);

            // Imprime a lista
            Console.WriteLine();
            ProdutoImprimir.Imprimir(listaDeProdutos);

            // Cadastra novos produtos
            Console.WriteLine();
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

                // instancia objeto do tipo ProdutoServico
                ProdutoServico servico = new ProdutoServico(listaDeProdutos);

                // chama metodo para salvar o objeto na lista
                servico.Cadastro(produto);
                
                // salvo os dados da lista em JSON no arquivo 
                OperacaoBancoDados.Salvar(listaDeProdutos);

                Console.WriteLine();
                Console.WriteLine("Este item foi cadastrado:");
                Console.WriteLine(string.Join(" - ", produto.ToString()));
            }            
        }
    }
}