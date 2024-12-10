using System.ComponentModel.DataAnnotations;

namespace _2024_2C_SushiPOP_G1.Models
{
    public class CarritoItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloNumeros12, ErrorMessage = ErrorViewModel.SoloNumeros)]
        public decimal PreiocUnitarioConDescuento { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloNumeros12, ErrorMessage = ErrorViewModel.SoloNumeros)]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        public int CarritoId { get; set; }
        public Carrito? Carrito { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        public int ProductoId { get; set; }
        public Producto? Producto{ get; set; }
    }
}
