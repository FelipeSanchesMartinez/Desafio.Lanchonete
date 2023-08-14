namespace Desafio.Lanchonete.Service.Model
{
    public class Produto
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public List<Produto> Adicionais { get; set; }

        public bool AcompanhamentoValido(string acompanhamento)
        {
            if (Adicionais == null || Adicionais.Any() == false) return true;
            bool valido =  Adicionais.Exists(adicional => adicional.Codigo == acompanhamento);
            return valido;
        }
            
    }
}
