using CalculatorTech.Models.TabelaDitribuicaoFrequencia;

namespace CalculatorTech.Services.Interfaces
{
    public interface IEstatisticaService
    {
        public TabelaDistribuicaoFrequencia RetornarTabelaDistribuicaoDeFrequencia(string[] valores);
    }
}
