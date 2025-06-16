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

            // Instancia um objeto para verificaçao do id
            ProdutoServico produtoServico = new ProdutoServico(listaDeProdutos);

            // Imprime a quantidade de objetos na lista
            Console.WriteLine("Itens carregados: " + listaDeProdutos.Count);

            // Imprime a lista
            Console.WriteLine();
            ProdutoImprimir.Imprimir(listaDeProdutos);


            // Cadastra novos produtos - CRUD - CREATE
            Console.WriteLine();
            Console.Write("Digite SIM ou NAO para cadastrar novos produtos: ");
            string simOuNao = Console.ReadLine();

            if (simOuNao.ToLower() == "sim")

            {
                Console.Write("Digite o ID do produto: ");
                int id = int.Parse(Console.ReadLine());

                // Verifica a disponibilidade do ID               
                bool testaId = produtoServico.VerificaId(listaDeProdutos, id);

                while (testaId == false)
                {
                    Console.Write("Esse id nao esta disponivel, digite outro:");
                    id = int.Parse(Console.ReadLine());
                    testaId = produtoServico.VerificaId(listaDeProdutos, id);
                }

                Console.Write("Digite o NOME do Produto: ");
                string nome = Console.ReadLine();
                Console.Write("Digite o PRECO do produto: ");
                double preco = double.Parse(Console.ReadLine());
                Console.Write("Digite a QUANTIDADE do produto: ");
                int quantidade = int.Parse(Console.ReadLine());

                // cria um objeto com todos os atributos da classe protudo
                Produto novoProduto = new Produto(id, nome, preco, quantidade);

                // instancia objeto do tipo ProdutoServico passando a lista JSON
                ProdutoServico servico = new ProdutoServico(listaDeProdutos);

                // chama metodo para salvar o novo objeto na lista
                servico.Cadastro(novoProduto);

                // coverte os dados da lista em JSON e os salva no arquivo JSON
                OperacaoBancoDados.Salvar(listaDeProdutos);

                // mostra o item que foi adicionado na lista
                Console.WriteLine();
                Console.WriteLine("Este item foi cadastrado:");
                Console.WriteLine(string.Join(" - ", novoProduto.ToString()));
            }


            // Busca e imprime um produto especifico - CRUD - READ
            Console.WriteLine();
            Console.Write("Quer Imprimir algum item especifico? ");
            simOuNao = Console.ReadLine();

            if (simOuNao.ToLower() == "sim")
            {
                Console.Write("Digite o ID do produto a ser impresso: ");
                int buscaId = int.Parse(Console.ReadLine());

                // instancia uma variavel e chama o metodo de BuscaProduto
                Produto produtoAImprimir = produtoServico.BuscaProduto(buscaId);

                Console.WriteLine(produtoAImprimir.ToString());
            }


            // Atualiza um produto - CRUD - UPDATE
            Console.WriteLine();
            Console.Write("Quer alterar algum produto da lista? ");
            simOuNao = Console.ReadLine();

            if (simOuNao.ToLower() != "nao")
            {
                Console.Write("Digite o ID do produto a ser alterado: ");
                int buscaId = int.Parse(Console.ReadLine());

                // atribui a um novo objeto o retorno do metodo BuscaProduto
                Produto produtoASerAlterado = produtoServico.BuscaProduto(buscaId);

                // cadastra NOME
                Console.Write("Digite o NOME do produto: ");
                produtoASerAlterado.Nome = Console.ReadLine();
                
                // cadastra PREÇO
                Console.Write("Digite o PRECO do produto: ");
                if (!double.TryParse(Console.ReadLine(), out double preco))
                {
                    Console.WriteLine("Preço invalido, tente novamente.");
                    return;
                }
                produtoASerAlterado.Preco = preco;
                
                // cadastra QUANTIDADE
                Console.Write("Digite a QUANTIDADE: ");
                if (!int.TryParse(Console.ReadLine(), out int quantidade))
                {
                    Console.WriteLine("Quantidade invalida, tente novamente.");
                    return;
                }
                produtoASerAlterado.Quantidade = quantidade;

                // salva a lista no arquivo JSON
                OperacaoBancoDados.Salvar(listaDeProdutos);
                Console.WriteLine("Esse item foi alterado:" + produtoASerAlterado);
            }

















            // Exclui um produto - CRUD - DELETE
            Console.WriteLine();
            Console.Write("Quer excluir algum produto da lista? ");
            simOuNao = Console.ReadLine();

            if (simOuNao == "sim")
            {

            }
        }
    }
}
