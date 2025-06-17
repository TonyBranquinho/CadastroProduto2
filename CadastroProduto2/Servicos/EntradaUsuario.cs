using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProduto2.Servicos
{
    internal static class EntradaUsuario
    {
        // Validaçao com TryParse de INTEIRO
        public static int LerInteiro(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                if (int.TryParse(Console.ReadLine(), out int valor))
                {
                    return valor;
                }

                Console.WriteLine("Valor invalido, Tente novamente.");
            }
        }

        // Validaçao com TryParse de DOUBLE
        public static double LerDouble(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                if (double.TryParse(Console.ReadLine(), out double valor))
                    {
                    return valor;
                }

                Console.WriteLine("Valor invalido, Tente novamente.");
            }
        }
    }
}
