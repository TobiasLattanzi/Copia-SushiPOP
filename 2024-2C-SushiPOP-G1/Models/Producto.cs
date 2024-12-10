using System.ComponentModel.DataAnnotations;

namespace _2024_2C_SushiPOP_G1.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloLetrasAZ, ErrorMessage = ErrorViewModel.SoloLetras)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = ErrorViewModel.Longitud)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [StringLength(250, MinimumLength = 20, ErrorMessage = ErrorViewModel.Longitud)]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloNumeros12, ErrorMessage = ErrorViewModel.SoloNumeros)]
        public decimal Precio { get; set; }

        public string Foto { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloNumeros12, ErrorMessage = ErrorViewModel.SoloNumeros)]
        public int Stock { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloNumeros12, ErrorMessage = ErrorViewModel.SoloNumeros)]
        public decimal Costo { get; set; }
        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public List<Descuento>? Descuentos { get; set; }
        public List<CarritoItem>? Items { get; set; }
    }
}
