using System.ComponentModel.DataAnnotations;

namespace _2024_2C_SushiPOP_G1.Models
{
	public class Pedido
	{
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloNumeros12, ErrorMessage = ErrorViewModel.SoloNumeros)]
        public int NroPedido { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [DataType(DataType.DateTime, ErrorMessage = ErrorViewModel.FechaInvalida)]
        public DateTime FechaDeCompra { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloNumeros12, ErrorMessage = ErrorViewModel.SoloNumeros)]
        public decimal SubTotal { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloNumeros12, ErrorMessage = ErrorViewModel.SoloNumeros)]
        public decimal GastoEnvio { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloNumeros12, ErrorMessage = ErrorViewModel.SoloNumeros)]
        public decimal Total { get; set; }

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        [RegularExpression(ErrorViewModel.SoloNumeros12, ErrorMessage = ErrorViewModel.SoloNumeros)]
        public bool Estado { get; set; }
		public int CarritoId { get; set; }
		public Carrito? Carrito { get; set; }
		public Reclamo? Reclamo { get; set; }
	}
}
