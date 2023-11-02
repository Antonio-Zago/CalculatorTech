using Microsoft.AspNetCore.Mvc;

namespace CalculatorTech.Controllers
{
    public class EstatisticaController : Controller
    {
        public IActionResult DistribuicaoFrequencia()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Calcular(String[] valor)
        {

            return View();
        }
    }
}
