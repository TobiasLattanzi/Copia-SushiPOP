using System.ComponentModel.DataAnnotations;

namespace _2024_2C_SushiPOP_G1.Models
{
	public class Reserva
	{
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloLetrasAZ, ErrorMessage = ErrorViewModel.SoloLetras)]
        public string Local { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [DataType(DataType.DateTime, ErrorMessage = ErrorViewModel.FechaInvalida)]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        public bool Confirmada { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloLetrasAZ, ErrorMessage = ErrorViewModel.SoloLetras)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloLetrasAZ, ErrorMessage = ErrorViewModel.SoloLetras)]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
