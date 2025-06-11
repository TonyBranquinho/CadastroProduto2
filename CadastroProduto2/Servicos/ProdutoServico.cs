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
        public List<Produto> listaProdutos { get; private set; }

        public ProdutoServico() 
        {
        }
    }
}
