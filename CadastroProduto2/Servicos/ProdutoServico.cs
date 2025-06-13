using CadastroProduto2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProduto2.Servicos
{
    internal class ProdutoServico
    {
        public List<Produto> lista { get; private set; } = new List<Produto>();

        public ProdutoServico() 
        {
        }

        // CADASTRA PRODUTO
        public void Cadastro(Produto produto)
        {
            lista.Add(produto);
        }
    }
}
