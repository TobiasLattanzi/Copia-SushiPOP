using System.ComponentModel.DataAnnotations;

namespace _2024_2C_SushiPOP_G1.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloLetrasAZ, ErrorMessage = ErrorViewModel.SoloLetras)]
        [StringLength(255, MinimumLength = 1, ErrorMessage = ErrorViewModel.LongitudFija)]

        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloLetrasAZ, ErrorMessage = ErrorViewModel.SoloLetras)]
        public string Msj { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        public bool Leido { get; set; }
    }
}
