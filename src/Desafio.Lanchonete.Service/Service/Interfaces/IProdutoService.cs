using Desafio.Lanchonete.Service.Model;

namespace Desafio.Lanchonete.Service.Service.Interfaces
{
    public interface IProdutoService
    {
        double CalcularValorDaCompra(List<string> codigos, List<int> quantidades, string formaDePagamento);
        List<Produto> GetListaProdutos();
        Produto GetProdutoPorCodigo(string nome);
        bool PodeComprar(List<string> nomes);
    }
}