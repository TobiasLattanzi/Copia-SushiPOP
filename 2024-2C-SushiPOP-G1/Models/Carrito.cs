using System.ComponentModel.DataAnnotations;

namespace _2024_2C_SushiPOP_G1.Models
{
	public class Carrito
	{
		[Key]
		public int Id { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        public bool Procesando { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        public bool Cancelado { get; set; }

		public Pedido? Pedido { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        public int ClienteId { get; set; }

		public Cliente? Cliente { get; set; }
		public List<CarritoItem>? CarritoItems { get; set; }
    }
}
