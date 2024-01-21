using CalculadoraLumens.Models;

namespace CalculadoraLumens.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        public ResultadoViewModel CalcularLumens(RoomModel comodo)
        {
            var (MinLumens, MaxLumens) = CalcularValorLumens(comodo.TipoComodo);
            var (MinTemp, MaxTemp) = CalcularValorTemperatura(comodo.TipoComodo);

            ResultadoViewModel resultadoViewModel = new()
            {
                LumensMin = (int)(MinLumens * comodo.Largura * comodo.Comprimento),
                LumensMax = (int)(MaxLumens * comodo.Largura * comodo.Comprimento),
                TemperaturaMin = MinTemp,
                TemperaturaMax = MaxTemp,
                TomDaCor = DefinirTom(MinTemp, MaxTemp)
            };

            return resultadoViewModel;
        }

        private static (double Min, double Max) CalcularValorLumens(string tipoComodo)
        {
            var (Intervalo, Min, Max) = ObterConfiguracaoLumens(tipoComodo);

            return Intervalo ? (Min, Max) : (Min, Min);
        }

        private static (bool Intervalo, double Min, double Max) ObterConfiguracaoLumens(string tipoComodo)
        {
            return tipoComodo.ToLower() switch
            {
                "sala de estar" => (Intervalo: true, Min: 50, Max: 100),
                "cozinha" => (Intervalo: true, Min: 300, Max: 500),
                "corredor" => (Intervalo: false, Min: 150, Max: 0),
                "quarto" => (Intervalo: false, Min: 50, Max: 0),
                "banheiro" => (Intervalo: false, Min: 100, Max: 0),
                "lavanderia" => (Intervalo: false, Min: 50, Max: 0),
                "garagem" => (Intervalo: false, Min: 50, Max: 0),
                "corredor externo" => (Intervalo: true, Min: 50, Max: 150),
                _ => (Intervalo: false, Min: 0, Max: 0),
            };
        }

        private static (int Min, int Max) CalcularValorTemperatura(string tipoComodo)
        {
            return ObterConfiguracaoTemperatura(tipoComodo);
        }

        private static (int Min, int Max) ObterConfiguracaoTemperatura(string tipoComodo)
        {
            return tipoComodo.ToLower() switch
            {
                "sala de estar" => (Min: 2700, Max: 3000),
                "cozinha" => (Min: 3500, Max: 4500),
                "corredor" => (Min: 3500, Max: 4500),
                "quarto" => (Min: 2700, Max: 3000),
                "banheiro" => (Min: 3500, Max: 4500),
                "lavanderia" => (Min: 3500, Max: 4500),
                "garagem" => (Min: 5000, Max: 6500),
                "corredor externo" => (Min: 5000, Max: 6500),
                _ => (Min: 0, Max: 0),
            };
        }

        private static string DefinirTom(int temperaturaMin, int temperaturaMax)
        {
            if (temperaturaMin >= 2600 && temperaturaMax <= 3500)
            {
                return "Quente";
            }
            else if (temperaturaMin >= 4000 && temperaturaMax <= 5500)
            {
                return "Neutro";
            }
            else
            {
                return "Frio";
            }
        }
    }
}
