using Desafio.Lanchonete.Service.Model;

namespace Desafio.Lanchonete.Service.Service.Interfaces
{
    public interface IFormaDePagamentoService
    {
        double CalcularValorDeAcordoComFormaDePagemento(string formaDePagamentoNome, int quantidade, double valorProduto);
        List<FormaDePagamento> GetPagamento();
        FormaDePagamento ObterFormadePagamento(string nome);
    }
}