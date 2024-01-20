using CalculadoraLumens.Models;

namespace CalculadoraLumens.IServices
{
    public interface ICalculadoraService
    {
        ResultadoViewModel CalcularLumens(RoomModel comodo);
    }
}