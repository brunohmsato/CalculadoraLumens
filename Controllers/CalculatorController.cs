using CalculadoraLumens.Models;
using CalculadoraLumens.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CalculadoraLumens.Controllers
{
    public class CalculatorController(ICalculadoraService calculadoraService) : Controller
    {
        private readonly ICalculadoraService _calculadoraService = calculadoraService;

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult CalcularLumens(RoomModel comodo)
        {
            if (ModelState.IsValid)
            {
                try
                {

                ResultadoViewModel resultadoViewModel = _calculadoraService.CalcularLumens(comodo);
                return View("Resultado", resultadoViewModel);

                }
                catch
                {
                    return RedirectToAction("Privacy", "Home");
                }
            }
            return RedirectToAction("Privacy", "Home");
        }
    }
}
