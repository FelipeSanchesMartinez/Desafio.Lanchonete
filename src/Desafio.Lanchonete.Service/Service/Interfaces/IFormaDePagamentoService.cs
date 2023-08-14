using Desafio.Lanchonete.Service.Model;

namespace Desafio.Lanchonete.Service.Service.Interfaces
{
    public interface IFormaDePagamentoService
    {
        List<FormaDePagamento> GetPagamento();
        FormaDePagamento ObterFormadePagamento(string nome);
    }
}