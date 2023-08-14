using Desafio.Lanchonete.Service.Model;
using Desafio.Lanchonete.Service.Service.Interfaces;

namespace Desafio.Lanchonete.Service.Service
{
    public class ProdutoService : IProdutoService
    {
        IFormaDePagamentoService _formaDePagamento;

        public ProdutoService(IFormaDePagamentoService formaDePagamento)
        {
            _formaDePagamento = formaDePagamento;
        }

        public List<Produto> GetListaProdutos()
        {
            Produto produto1 = new Produto() { Codigo = "cafe", Descricao = "Café", Valor = 3, Adicionais = new List<Produto>() { new Produto() { Codigo = "chantily" } } };
            Produto produto2 = new Produto() { Codigo = "chantily", Descricao = "Chantily (extra do Café)", Valor = 1.5 };
            Produto produto3 = new Produto() { Codigo = "suco", Descricao = "Suco Natural", Valor = 6.2 };
            Produto produto4 = new Produto() { Codigo = "sanduiche", Descricao = "Sanduíche", Valor = 6.5, Adicionais = new List<Produto>() { new Produto { Codigo = "queijo", } } };
            Produto produto5 = new Produto() { Codigo = "queijo", Descricao = "Queijo (extra do Sanduíche)", Valor = 2 };
            Produto produto6 = new Produto() { Codigo = "salgado", Descricao = "Salgado", Valor = 7.25 };
            Produto produto7 = new Produto() { Codigo = "combo1", Descricao = "1 Suco e 1 Sanduíche", Valor = 9.5 };
            Produto produto8 = new Produto() { Codigo = "combo2", Descricao = "1 Café e 1 Sanduíche", Valor = 7.5 };


            List<Produto> produtosCadastrados = new List<Produto>()
        {
            produto1, produto2, produto3, produto4, produto5, produto6, produto7, produto8
        };

            return produtosCadastrados;
        }

        public Produto GetProdutoPorCodigo(string nome)
        {

            var ListaDeProdutos = GetListaProdutos();
            return ListaDeProdutos.FirstOrDefault(produto => produto.Codigo == nome);

        }

        public double CalcularValorDaCompra(List<string> codigos, List<int> quantidades, string formaDePagamento)
        {

            double total = 0;

            FormaDePagamento objFormaDePagamento = _formaDePagamento.ObterFormadePagamento(formaDePagamento);
            var quantidadeDeCodigos = codigos.Count;

            for (int indice = 0; indice < quantidadeDeCodigos; indice++)
            {
                string codigoAtual = codigos[indice];
                int qunatidadeAtual = quantidades[indice];

                var produto = GetProdutoPorCodigo(codigoAtual);


                if (produto != null)
                {
                   double valorDoFor = objFormaDePagamento.CalcularTotal(qunatidadeAtual, produto.Valor);
                    total += valorDoFor;
                  
                }
            }
            return total;
        }
    }
}
