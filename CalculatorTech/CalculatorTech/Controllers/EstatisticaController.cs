using CalculatorTech.Models;
using CalculatorTech.Models.TabelaDitribuicaoFrequencia;
using CalculatorTech.Services;
using CalculatorTech.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorTech.Controllers
{
    public class EstatisticaController : Controller
    {
        private readonly IEstatisticaService _estatisticaService;

        public EstatisticaController(IEstatisticaService estatisticaService)
        {
            _estatisticaService = estatisticaService;
        }

        public IActionResult DistribuicaoFrequencia( bool adicionarLinha, string[] valor)
        {
            if (TempData["numeroLinhasGridEntrada"] == null)
            {
                TempData["numeroLinhasGridEntrada"] = 5;
            };
            if (adicionarLinha)
            {
                TempData["numeroLinhasGridEntrada"] = (int)TempData["numeroLinhasGridEntrada"] + 1;
            }
            
            if (valor.Length != 0)
            { 
                TabelaDistribuicaoFrequencia tabelaDistribuicaoFrequencia = new TabelaDistribuicaoFrequencia();
                tabelaDistribuicaoFrequencia = _estatisticaService.RetornarTabelaDistribuicaoDeFrequencia(valor);
                tabelaDistribuicaoFrequencia.Valores = valor.ToList();
                return View(tabelaDistribuicaoFrequencia);
            }
            

            return View();
        }

        public RedirectToActionResult AdicionarLinhasGrid()
        {

            return RedirectToAction("DistribuicaoFrequencia", new { adicionarLinha = true});
        }


    }
}
