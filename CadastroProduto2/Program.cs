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






            // CADASTRA NOVOS PRODUTOS - CRUD - CREATE
            Console.WriteLine();
            Console.Write("Digite SIM ou NAO para cadastrar novos produtos: ");
            string simOuNao = Console.ReadLine();

            if (simOuNao.ToLower() == "sim")

            {   // Salva o ID digitado usando metodo com TryParse
                int id = EntradaUsuario.LerInteiro("Digite o ID do produto: ");

                // Verifica a disponibilidade do ID               
                bool testaId = produtoServico.VerificaId(listaDeProdutos, id);

                while (testaId == false)
                {
                    id = EntradaUsuario.LerInteiro("Esse id nao esta disponivel, digite outro:");
                    testaId = produtoServico.VerificaId(listaDeProdutos, id);
                }



                // Cadastra NOME do produto
                Console.Write("Digite o NOME do Produto: ");
                string nome = Console.ReadLine();

                // Cadastra PREÇO usando metodo com TryParse
                double preco = EntradaUsuario.LerDouble("Digite o PREÇO do produto ");

                // Cadastra QUANTIDADE usando metodo com TryParse
                int quantidade = EntradaUsuario.LerInteiro("Digite a QUANTIDADE do produto ");



                // Cria um objeto com todos os atributos da classe protudo
                Produto novoProduto = new Produto(id, nome, preco, quantidade);

                // Instancia objeto do tipo ProdutoServico passando a lista JSON
                ProdutoServico servico = new ProdutoServico(listaDeProdutos);

                // Chama metodo para salvar o novo objeto na lista
                servico.Cadastro(novoProduto);

                // Coverte os dados da lista em JSON e os salva no arquivo JSON
                OperacaoBancoDados.Salvar(listaDeProdutos);

                // Mostra o item que foi adicionado na lista
                Console.WriteLine();
                Console.WriteLine("Este item foi cadastrado:");
                Console.WriteLine(string.Join(" - ", novoProduto.ToString()));
            }









            // BUSCA E IMPRIME UM PRODUTO ESPECIFICO - CRUD - READ
            Console.WriteLine();
            Console.Write("Quer Imprimir algum item especifico? ");
            simOuNao = Console.ReadLine();

            if (simOuNao.ToLower() == "sim")
            {
                // Salva o ID digitado usando metodo com TryParse
                int buscaId = EntradaUsuario.LerInteiro("Digite o ID do produto a ser impresso: ");

                // Atribui a um novo objeto o retorno do metodo de BuscaProduto
                Produto produtoAImprimir = produtoServico.BuscaProduto(buscaId);

                // Imprime o produto escolhido
                Console.WriteLine(produtoAImprimir.ToString());
            }








            // ATUALIZA UM PRODUTO - CRUD - UPDATE
            Console.WriteLine();
            Console.Write("Quer alterar algum produto da lista? ");
            simOuNao = Console.ReadLine();

            if (simOuNao.ToLower() != "nao")
            {
                // Salva o ID digitado usando metodo com TryParse
                int buscaId = EntradaUsuario.LerInteiro("Digite o ID do produto a ser alterado: ");

                // Atribui a um novo objeto, o retorno do metodo BuscaProduto
                Produto produtoASerAlterado = produtoServico.BuscaProduto(buscaId);


                // Cadastra NOME
                Console.Write("Digite o NOME do produto: ");
                produtoASerAlterado.Nome = Console.ReadLine();
                
                // Cadastra PREÇO usando metodo com TryParse
                double preco = EntradaUsuario.LerDouble("Digite o PRECO do produto: ");

                // Cadastra QUANTIDADE usando metodo com TryParse
                int quantidade = EntradaUsuario.LerInteiro("Digite a QUANTIDADE: ");
                

                // Salva a lista no arquivo JSON
                OperacaoBancoDados.Salvar(listaDeProdutos);

                // Imprime o PRODUTO que foi alterado
                Console.WriteLine();
                Console.WriteLine("Esse item foi alterado:" + produtoASerAlterado);
            }








            // EXCLUI UM PRODUTO - CRUD - DELETE
            Console.WriteLine();
            Console.Write("Quer excluir algum produto da lista? ");
            simOuNao = Console.ReadLine();

            if (simOuNao.ToLower() == "sim")
            {
                // Salva o ID usando metodo com TryParse
                int buscaId = EntradaUsuario.LerInteiro("Digite o ID do produto a ser EXCLUIDO ");

                // Busca na lista o ID digitado
                Produto excluiProduto = produtoServico.BuscaProduto(buscaId);

                // Imprime item exlcuido
                Console.WriteLine("Esse produto foi excluido: " + excluiProduto);

                // Remove o item da lista
                listaDeProdutos.Remove(excluiProduto);

                // Salva lista no arquivo JSON
                OperacaoBancoDados.Salvar(listaDeProdutos);
            }
        }
    }
}
