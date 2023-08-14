using Desafio.Lanchonete.Service.Model;
using Desafio.Lanchonete.Service.Service;
using Desafio.Lanchonete.Service.Service.Interfaces;

namespace Desafio.Lanchonete.UnitTests.Model
{
    public class FormaDePagamentoTest
    {

        FormaDePagamentoService _formaDePagamento;
        

        public FormaDePagamentoTest()
        {
            _formaDePagamento = new FormaDePagamentoService();
            
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
            var total = filteredFormaDePagamento.CalcularTotal(2,6.2);

            Assert.Equal(12.4, total);
        }
    }
}
