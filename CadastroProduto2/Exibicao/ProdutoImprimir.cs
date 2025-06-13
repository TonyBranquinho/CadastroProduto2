using CadastroProduto2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProduto2.Exibicao
{
    internal class ProdutoImprimir
    {
        public static void Imprimir(List<Produto> lista)
        {
            foreach (Produto p in lista) 
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}
