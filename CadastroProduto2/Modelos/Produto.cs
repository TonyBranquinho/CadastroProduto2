using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProduto2.Modelos
{
    internal class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }

        public Produto()
        {
        }
        public Produto(int id, string nome, double preco, int quantidade)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        public override string ToString()
        {
            return string.Format("{0,-3} {1,-22}R$ {2,-8} {3,-4}UNIDADES",
                Id, Nome, Preco, Quantidade);
        }
    }
}
