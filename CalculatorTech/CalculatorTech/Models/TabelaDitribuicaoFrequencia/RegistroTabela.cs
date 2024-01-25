namespace CalculatorTech.Models.TabelaDitribuicaoFrequencia
{
    public class RegistroTabela
    {
        public double DeClasse { get; set; }

        public double AteClasse { get; set; }

        public int FrequenciaAbsoluta { get; set; }

        public double FrequenciaRelativa { get; set; }

        public int FrequenciaAbsolutaAcumulada { get; set; }

        public double FrequenciaRelativaAcumulada { get; set; }
    }
}
