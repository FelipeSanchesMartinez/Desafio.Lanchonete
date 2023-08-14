using Desafio.Lanchonete.Service.Model;
using Desafio.Lanchonete.Service.Service;
using Desafio.Lanchonete.Service.Service.Interfaces;

namespace Desafio.Lanchonete.UnitTests.Model
{
    public class ProdutoTest
    {
       
        ProdutoService _produtoService;

        public ProdutoTest()
        {
            IFormaDePagamentoService formaDePagamento = new FormaDePagamentoService();
            _produtoService = new ProdutoService(formaDePagamento);
      
        }

        [Fact]
        public void ShouldCreateAProdutoWithSuccess()
        {
            var combo1 = new Produto() { Codigo = "combo1", Descricao = "1 Suco e 1 Sanduíche", Valor = 9.5 };

            Assert.Equal("combo1", combo1.Codigo);
        }

        [Fact]
        public void ShouldGetProdutoPorCodigo()
        {
            var produto = _produtoService.GetProdutoPorCodigo("suco");

            Assert.Equal("suco", produto.Codigo);
        }

        [Fact]
        public void ShouldCalcularValorDaCompra()
        {
            List<int> inteiros = new List<int>() { 1, 2 };
            List<string> codigos = new List<string>() { "cafe", "suco" };
            var valorTotal = _produtoService.CalcularValorDaCompra(codigos, inteiros,"debito");
            

            Assert.Equal(15.4, valorTotal);
        }
    
    }
}
