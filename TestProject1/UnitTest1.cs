using Desafio.Lanchonete.Service.Model;
using Desafio.Lanchonete.Service.Service;

namespace TestProject1
{
    public class UnitTest1
    {

        FormaDePagamentoService _formaDePagamento;

        public UnitTest1()
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
        public void GetFormaDePagamentoByName()
        {
            var filteredFormaDePagamento = _formaDePagamento.ObterFormadePagamento("dinheiro");

            Assert.Equal("dinheiro", filteredFormaDePagamento.Nome);
        }

        [Fact]
        public void GetTotalByFomaDePagamento()
        {
            var filteredFormaDePagamento = _formaDePagamento.ObterFormadePagamento("debito");
            var total = filteredFormaDePagamento.CalcularTotal(2, 3);

            Assert.Equal(6, total);
        }
    }
}
