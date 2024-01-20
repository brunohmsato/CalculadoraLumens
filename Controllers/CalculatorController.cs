using CalculadoraLumens.IServices;
using CalculadoraLumens.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraLumens.Controllers
{
    public class CalculatorController(ICalculadoraService calculadoraService) : Controller
    {
        private readonly ICalculadoraService _calculadoraService = calculadoraService;

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult CalcularLumens(RoomModel comodo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ResultadoViewModel resultadoViewModel = _calculadoraService.CalcularLumens(comodo);

                    return View("Resultado", resultadoViewModel);
                }
                return View("Index", comodo);
            }
            catch (Exception)
            {
                return RedirectToAction("Erro", "Home");
            }
        }
    }
}
