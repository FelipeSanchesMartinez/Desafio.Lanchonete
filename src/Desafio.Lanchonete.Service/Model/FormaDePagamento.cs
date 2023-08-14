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
            

            if (!AcrescentarPorcentagemDesconto && !AcrescentarPorcentagemAcrescimo)
            {
                double valor = quantidade * valorProduto;
                return valor;
            }
            else if (AcrescentarPorcentagemDesconto)
            {
                double valor = quantidade * valorProduto;
                var porcentagemDecimal = new decimal(PorcentagemPagamento);
                var divisao = new decimal(100);
                var valorDecimal = new decimal(valor);
                var calculo = valorDecimal - (valorDecimal * (porcentagemDecimal/divisao));
                return Convert.ToDouble(calculo);

            }
            else
            {
                double valor = quantidade * valorProduto;
                var porcentagemDecimal = new decimal(PorcentagemPagamento);
                var divisao = new decimal(100);
                var valorDecimal = new decimal(valor);
                var calculo = valorDecimal + (valorDecimal * (porcentagemDecimal / divisao));
                return Convert.ToDouble(calculo);
            }
        }

    }

}
