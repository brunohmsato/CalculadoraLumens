using CalculadoraLumens.Models;

namespace CalculadoraLumens.Services
{
    public interface ICalculadoraService
    {
        ResultadoViewModel CalcularLumens(RoomModel comodo);
    }
}