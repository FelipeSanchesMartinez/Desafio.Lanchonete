using Desafio.Lanchonete.Service.Model;
using Desafio.Lanchonete.Service.Service.Interfaces;

namespace Desafio.Lanchonete.Service.Service
{
    public class FormaDePagamentoService : IFormaDePagamentoService
    {
        public List<FormaDePagamento> GetPagamento()
        {
            FormaDePagamento formaDePagamento1 = new FormaDePagamento() { Nome = "dinheiro", AcrescentarPorcentagemAcrescimo = false, AcrescentarPorcentagemDesconto = true, PorcentagemPagamento = 5 };
            FormaDePagamento formaDePagamento2 = new FormaDePagamento() { Nome = "debito", AcrescentarPorcentagemAcrescimo = false, AcrescentarPorcentagemDesconto = false, PorcentagemPagamento = 0 };
            FormaDePagamento formaDePagamento3 = new FormaDePagamento() { Nome = "credito", AcrescentarPorcentagemAcrescimo = true, AcrescentarPorcentagemDesconto = false, PorcentagemPagamento = 3 };

            List<FormaDePagamento> formaDePagamentosCadastrados = new List<FormaDePagamento>()
        {
            formaDePagamento1, formaDePagamento2, formaDePagamento3
        };

            return formaDePagamentosCadastrados;

        }

        public FormaDePagamento ObterFormadePagamento(string nome)
        {
            var formasDePagamentos = GetPagamento();
            return formasDePagamentos.FirstOrDefault(forma => forma.Nome == nome);
        }

        
    }
}
