using System.Drawing;

namespace Desafio.Lanchonete.Service.Model
{
    public class FormaDePagamento
    {
        public string Nome { get; set; }
        public int PorcentagemPagamento { get; set; }
        public bool AcrescentarPorcentagemDesconto { get; set; }
        public bool AcrescentarPorcentagemAcrescimo { get; set; }


        public double CalcularTotal(int quantidade, double valorProduto)
        {
            double valor;

            if (!AcrescentarPorcentagemDesconto && !AcrescentarPorcentagemAcrescimo)
            {
                valor = +quantidade * valorProduto;

            }
            else if (AcrescentarPorcentagemDesconto)
            {
                double valorTotal = quantidade * valorProduto;
                var porcentagemDecimal = new decimal(PorcentagemPagamento);
                var divisao = new decimal(100);
                var valorDecimal = new decimal(valorTotal);
                var calculo = valorDecimal - (valorDecimal * (porcentagemDecimal / divisao));
                valor = Convert.ToDouble(calculo);
            }
            else
            {
                double valorTotal = quantidade * valorProduto;
                var porcentagemDecimal = new decimal(PorcentagemPagamento);
                var divisao = new decimal(100);
                var valorDecimal = new decimal(valorTotal);
                var calculo = valorDecimal + (valorDecimal * (porcentagemDecimal / divisao));
                valor = Convert.ToDouble(calculo);
            }
            return valor;

        }
    }
}
