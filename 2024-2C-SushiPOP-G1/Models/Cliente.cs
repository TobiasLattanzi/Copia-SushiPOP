using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2024_2C_SushiPOP_G1.Models
{

    public class Cliente : Usuario
    {

        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        public int NumeroCliente { get; set; }
        public List<Carrito>? Carritos { get; set; }
        public List<Reserva>? Reservas { get; set; }
    }
}
