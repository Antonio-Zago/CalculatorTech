using CalculatorTech.Models.TabelaDitribuicaoFrequencia;
using CalculatorTech.Services.Interfaces;

namespace CalculatorTech.Services
{
    public class EstatisticaService : IEstatisticaService
    {

        public EstatisticaService()
        {
            ValoresConvertidos = new List<double>();
        }

        public double NumeroDeClasses { get; set; }

        public double AmplitudeTotal { get; set; }

        public double AmplitudeClasses { get; set; }

        public List<double> ValoresConvertidos{ get; set; }

        public int FrequenciaAbsolutaTotal { get; set; }


        public TabelaDistribuicaoFrequencia RetornarTabelaDistribuicaoDeFrequencia(string[] valores)
        {
            var valoresNaoNulos = valores.Where(a => !String.IsNullOrEmpty(a)).ToArray();
            var tabela = new TabelaDistribuicaoFrequencia();
            if (valoresNaoNulos.Length > 0)
            {
                OrganizarOrdemCrescenteValores(valoresNaoNulos);
                NumeroDeClasses = RetornarNumeroDeClasses(valoresNaoNulos);
                AmplitudeTotal = RetornarAmplitudeTotal(valoresNaoNulos);
                if (AmplitudeTotal == 0)
                {
                    return tabela;
                }
                AmplitudeClasses = RetornarAmplitudeClasses();
                tabela.RegistrosTabela = RetornarResgistrosDaTabela();




                return tabela;
            }
            return tabela;


        }

        private List<RegistroTabela> RetornarResgistrosDaTabela()
        {

            List<RegistroTabela> registrosTabela = new List<RegistroTabela>();

            for (var indiceClasse = 0; indiceClasse <= NumeroDeClasses; indiceClasse++)
            {
                AdicionarRegistroTabela(indiceClasse, registrosTabela);
            }
            if (registrosTabela.Last().AteClasse<= ValoresConvertidos.Last())
            {
                AdicionarRegistroTabela((int)NumeroDeClasses + 1, registrosTabela);

            }


            return registrosTabela;
        }

        private void AdicionarRegistroTabela(int indiceClasse, List<RegistroTabela> registrosTabela)
        {
            var registro = new RegistroTabela();
            if (indiceClasse == 0)
            {
                registro.DeClasse = ValoresConvertidos[0];
                FrequenciaAbsolutaTotal = 0;
            }
            else
            {
                registro.DeClasse = registrosTabela[indiceClasse - 1].AteClasse;
            }
            registro.AteClasse = Math.Round(registro.DeClasse + AmplitudeClasses,1);

            CalcularFrequenciaAbsolutaClasse(registro);
            FrequenciaAbsolutaTotal += registro.FrequenciaAbsoluta;

            registro.FrequenciaAbsolutaAcumulada = FrequenciaAbsolutaTotal;

            CalcularRelativaClasse(registro);
            CalcularFrequenciaRelativaAcumuladaClasse(registro);
            registrosTabela.Add(registro);
        }

        private void CalcularFrequenciaAbsolutaClasse(RegistroTabela registro)
        {
            var contadorFrequencia = 0;
            foreach (var valor in ValoresConvertidos)
            {
                if (valor >= registro.DeClasse && valor < registro.AteClasse)
                {
                    contadorFrequencia += 1;
                }
            }
            registro.FrequenciaAbsoluta = contadorFrequencia;
        }
        private void CalcularRelativaClasse(RegistroTabela registro)
        {
            registro.FrequenciaRelativa = Math.Round( ((double)registro.FrequenciaAbsoluta / (double)ValoresConvertidos.Count) *100,1);
        }

        private void CalcularFrequenciaRelativaAcumuladaClasse(RegistroTabela registro)
        {
            registro.FrequenciaRelativaAcumulada = Math.Round(((double)registro.FrequenciaAbsolutaAcumulada / (double)ValoresConvertidos.Count) * 100);
        }



        private double RetornarNumeroDeClasses(string[] valores)
        {
            

            return 1 + 3.3 * Math.Log10(valores.Count());
        }

        private double RetornarAmplitudeTotal(string[] valores)
        {

            return ValoresConvertidos[valores.Length - 1] - ValoresConvertidos[0];
        }

        private void OrganizarOrdemCrescenteValores(string[] valores)
        {
            ValoresConvertidos = ConverterArrayDeStringEmDouble(valores).OrderBy(a => a).ToList();
        }

        private List<double> ConverterArrayDeStringEmDouble(string[] valores)
        {
            var valoresConvertidos = valores.Select(a => {
                double numero;
                double.TryParse(a, out numero);
                return numero;
            }).ToList();

            return valoresConvertidos;

        }

        private double RetornarAmplitudeClasses()
        {
            return  Math.Round(AmplitudeTotal / NumeroDeClasses, 1) ;
        }


    }
}
