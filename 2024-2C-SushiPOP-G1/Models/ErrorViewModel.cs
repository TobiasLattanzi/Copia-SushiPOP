namespace _2024_2C_SushiPOP_G1.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public const string CampoObligatorio = "El campo {0} es obligatorio!";
        public const string Longitud = "El campo {0} debe tener entre {2} y {1} caracteres";
        public const string LongitudFija = "El campo {0} debe tener {1} caracteres/digitos";
        public const string SoloLetras = "El campo {0} solo admite caracteres de la A a la Z ";
        public const string FechaInvalida = "El valor no es una fecha y hora válida.";
        public const string SoloNumeros = "El campo {0} solo admite numeros.";


        public const string SoloLetrasAZ = @"^[a-zA-Z áéíóú]*";
        public const string SoloNumeros12 = @"^[0-9]+$";
        public const string DateFormat = "{0:yyyy-MM-dd HH:mm:ss}";
        public const string FormatoHora = @"^([01]?[0-9]|2[0-3]):[0-5][0-9]$";
        
    }
}
