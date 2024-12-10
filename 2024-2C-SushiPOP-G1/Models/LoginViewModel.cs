using System.ComponentModel.DataAnnotations;

namespace _2024_2C_SushiPOP_G1.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Nombre de usuario / correo electrónico")]
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; } = string.Empty;
    }
}
