using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2024_2C_SushiPOP_G1.Models
{

	public class Empleado : Usuario
    {
        [Required(ErrorMessage = ErrorViewModel.CampoObligatorio)]
        public int Legajo { get; set; }
 
    }
}