using CalculadoraLumens.IServices;
using CalculadoraLumens.Models;

namespace CalculadoraLumens.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        public ResultadoViewModel CalcularLumens(RoomModel comodo)
        {
            double valorLumens = CalcularValorLumensPorComodo(comodo.TipoComodo);
            double resultado = valorLumens * comodo.Largura * comodo.Comprimento;

            ResultadoViewModel resultadoViewModel = new()
            {
                Lumens = (int)resultado,
                TemperaturaCor = "2700K" // Exemplo, você precisa definir como calcular a temperatura de cor
            };

            return resultadoViewModel;
        }

        private static (bool UsaIntervalo, double Min, double Max) ObterConfiguracaoLumens(string tipoComodo)
        {
            return tipoComodo.ToLower() switch
            {
                "quarto" => (UsaIntervalo: true, Min: 20, Max: 50),
                "cozinha" => (UsaIntervalo: true, Min: 40, Max: 70),
                "banheiro" => (UsaIntervalo: false, Min: 30, Max: 0),// Exemplo: Banheiro usa um valor fixo de 30
                                                                     // Adicione outros casos conforme necessário
                _ => ((bool UsaIntervalo, double Min, double Max))(UsaIntervalo: false, Min: 0, Max: 0),// Valor padrão se o tipo de cômodo não for reconhecido
            };
        }

        private static double CalcularValorLumensPorComodo(string tipoComodo)
        {
            var (UsaIntervalo, Min, Max) = ObterConfiguracaoLumens(tipoComodo);

            if (UsaIntervalo)
            {
                // Lógica para calcular o valor dentro do intervalo
                double valorCalculado = (Min + Max) / 2;
                return valorCalculado;
            }
            else
            {
                // Valor fixo para cômodos que não utilizam um intervalo
                return Min;
            }
        }

    }
}
