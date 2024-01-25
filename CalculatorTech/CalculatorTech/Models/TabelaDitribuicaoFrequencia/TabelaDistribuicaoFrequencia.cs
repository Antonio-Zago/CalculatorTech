namespace CalculatorTech.Models.TabelaDitribuicaoFrequencia
{
    public class TabelaDistribuicaoFrequencia
    {
        public TabelaDistribuicaoFrequencia()
        {
            RegistrosTabela = new List<RegistroTabela>();
            Valores = new List<string>();
        }



        public List<RegistroTabela> RegistrosTabela { get; set; }

        public List<string> Valores { get; set; }


    }
}
