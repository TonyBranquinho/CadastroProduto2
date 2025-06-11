using CadastroProduto2.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CadastroProduto2.Servicos;

namespace CadastroProduto2.Dados
{
    internal class OperacaoBancoDados
    {        
        public static List<Produto> Carregar()
        {
            // Le o arquivo JSON e o armazena na varavel CONTEUDO
            string conteudo = File.ReadAllText("BancoDeDadosJson.json");

            // Converte o conteudo JSON em uma lista do tipo PRODUTO
            return JsonSerializer.Deserialize<List<Produto>>(conteudo);
        }

        public static void Salvar(List<Produto> listaProdutos)
        {
            // Converte a lista de produtos em texto JSON
            string conteudo = JsonSerializer.Serialize(listaProdutos);

            // Escreve o conteudo no arquivo JSON, substituindo o anterior
            File.WriteAllText("BancoDeDadosJson.json", conteudo);
        }
    }
}
