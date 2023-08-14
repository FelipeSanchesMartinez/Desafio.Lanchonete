using Desafio.Lanchonete.Service.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Lanchonete.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        IProdutoService _produtoService;
        IFormaDePagamentoService _formaDePagamentoService;

        public PedidoController(IProdutoService produtoService, IFormaDePagamentoService formaDePagamentoService)
        {
            _produtoService = produtoService;
            _formaDePagamentoService = formaDePagamentoService;
        }


        [HttpGet]
        public IActionResult FazerPedido([FromQuery] List<string> codigos, [FromQuery] List<int> quantidades, [FromQuery] string formaDePagamento = "")
        {
            var todosProdutos = _produtoService.GetListaProdutos();
            var formaPagamento = _formaDePagamentoService.ObterFormadePagamento(formaDePagamento);

            if (!codigos.Any())
            {
                return BadRequest("N�o h� itens no carrinho de compra!");

            }
            else if (!quantidades.Any())
            {
                return BadRequest("Quantidade inv�lida!");

            }
            else if (quantidades.Exists(quantidade => quantidade == 0))
            {
                return BadRequest("Quantidade inv�lida!");

            }
            else if (codigos.Exists(codigo => todosProdutos.Exists(produto => codigo == produto.Codigo) == false))
            {
                return BadRequest("Item inv�lido!");

            }
            else if (string.IsNullOrEmpty(formaDePagamento) || formaPagamento == null)
            {

                return BadRequest("Forma de pagamento inv�lida!");
            }
            else
            {

                var valorDaCompra = _produtoService.CalcularValorDaCompra(codigos, quantidades, formaDePagamento);
                return Ok(valorDaCompra);
            }
        }
    }
}