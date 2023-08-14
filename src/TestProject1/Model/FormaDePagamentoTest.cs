using Desafio.Lanchonete.Service.Model;
using Desafio.Lanchonete.Service.Service;
using Desafio.Lanchonete.Service.Service.Interfaces;

namespace Desafio.Lanchonete.UnitTests.Model
{
    public class FormaDePagamentoTest
    {

        FormaDePagamentoService _formaDePagamento;
        IProdutoService _produtoService;

        public FormaDePagamentoTest(IProdutoService produtoService)
        {
            _formaDePagamento = new FormaDePagamentoService();
            _produtoService = produtoService;
        }

        [Fact]
        public void ShouldCreateAFormaDePagamentoWithSuccess()
        {
            var debito = new FormaDePagamento() { Nome = "debito" };

            Assert.Equal("debito", debito.Nome);
        }

        [Fact]
        public void ShouldGetFormaDePagamentoByName()
        {
            var filteredFormaDePagamento = _formaDePagamento.ObterFormadePagamento("dinheiro");

            Assert.Equal("dinheiro", filteredFormaDePagamento.Nome);
        }

        [Fact]
        public void ShouldGetTotalByFomaDePagamentoClass()
        {
            var filteredFormaDePagamento = _formaDePagamento.ObterFormadePagamento("debito");
            var total = filteredFormaDePagamento.CalcularTotal(2, 3);

            Assert.Equal(6, total);
        }
        [Fact]
        public void ShouldGetTotalByFomaDePagamentoString()
        {
            
            var total = _formaDePagamento.CalcularValorDeAcordoComFormaDePagemento("debito",2, 3);

            Assert.Equal(6, total);
        }

       
    }
}
