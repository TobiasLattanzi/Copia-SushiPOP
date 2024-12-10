using System.ComponentModel.DataAnnotations;

namespace _2024_2C_SushiPOP_G1.Models
{
    public class Descuento
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloNumeros12, ErrorMessage = ErrorViewModel.SoloNumeros)]
        public int Dia { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloNumeros12, ErrorMessage = ErrorViewModel.SoloNumeros)]
        public int Porcentaje { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloNumeros12, ErrorMessage = ErrorViewModel.SoloNumeros)]
        public decimal DescuentoMax { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        public bool EstaActivo{ get; set; }
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
    }
}
