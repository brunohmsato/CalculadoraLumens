using System.ComponentModel.DataAnnotations;

namespace CalculadoraLumens.Models
{
    public class RoomModel
    {
        [Required(ErrorMessage = "A largura é obrigatória.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "A largura deve ser maior que zero.")]
        public double Largura { get; set; }

        [Required(ErrorMessage = "O comprimento é obrigatório.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "O comprimento deve ser maior que zero.")]
        public double Comprimento { get; set; }

        [Required(ErrorMessage = "Selecione o tipo de cômodo.")]
        public string TipoComodo { get; set; }
    }
}
