using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace _2024_2C_SushiPOP_G1.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloLetrasAZ, ErrorMessage = ErrorViewModel.SoloLetras)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = ErrorViewModel.Longitud)]
        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public List<Producto>? Productos { get; set; }
    }
}
