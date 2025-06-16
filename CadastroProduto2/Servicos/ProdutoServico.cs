using CadastroProduto2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CadastroProduto2.Servicos
{
    internal class ProdutoServico
    {
        public List<Produto> lista { get; private set; }

        // Construtor vazio
        public ProdutoServico()
        {
        }

        // Construtor recebendo a lista de Json como parametro
        public ProdutoServico(List<Produto> listaDeProdutos)
        {
            lista = listaDeProdutos;
        }

        // Metodo para Cadastrar produto
        public void Cadastro(Produto novoProduto)
        {
            lista.Add(novoProduto);
        }

        // Metodo para Verificar Id
        public bool VerificaId(List<Produto> listaDeProdutos, int id)
        {
            return !listaDeProdutos.Any(p => p.Id == id);
        }

        // Metodo para Buscar produto
        public Produto BuscaProduto(int buscaId)
        {
            Produto produtoEncontrado = lista.FirstOrDefault(p => p.Id == buscaId);

            if (produtoEncontrado != null)
            {
                return produtoEncontrado;
            }
            else
            {
                Console.WriteLine("Nao encontrei esse ID");
                return null;
            }
        }
























        // Metodo para Atualizar produto












        // Metodo para Excluir produto

    }
}
