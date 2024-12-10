using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2024_2C_SushiPOP_G1.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set;}


        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloLetrasAZ, ErrorMessage = ErrorViewModel.SoloLetras)]
        [StringLength(30, MinimumLength = 5, ErrorMessage = ErrorViewModel.Longitud)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloLetrasAZ, ErrorMessage = ErrorViewModel.SoloLetras)]
        [StringLength(30, MinimumLength = 5, ErrorMessage = ErrorViewModel.Longitud)]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloLetrasAZ, ErrorMessage = ErrorViewModel.SoloLetras)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = ErrorViewModel.Longitud)]
        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloNumeros12, ErrorMessage = ErrorViewModel.SoloNumeros)]
        [StringLength(10, MinimumLength = 10, ErrorMessage = ErrorViewModel.LongitudFija)]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [DataType(DataType.DateTime, ErrorMessage = ErrorViewModel.FechaInvalida)]
        public DateTime FechaNac { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [DataType(DataType.DateTime, ErrorMessage = ErrorViewModel.FechaInvalida)]
        public DateTime FechaAlta { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        public bool Activo { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        public string Email { get; set; } = string.Empty;

        [NotMapped]
        public string Clave { get; set; } = string.Empty; //consultar al profesor
    }
}
