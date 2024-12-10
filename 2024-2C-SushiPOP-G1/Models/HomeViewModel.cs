using Microsoft.CodeAnalysis;

namespace _2024_2C_SushiPOP_G1.Models
{
    public class HomeViewModel
    {

        //Crear view model HomeViewModel
        // dia (texto)
        // descuento
        // producto
        // mensaje?
        // horario


        public String? Mensaje { get; set; }

        public String? Horario { get; set; }


        public static String HorarioSemana = "Hoy " + DateTime.Now.DayOfWeek.ToString() + " de 19 a 23hs.";
        public static String HorarioFinde = "Hoy " + DateTime.Now.DayOfWeek.ToString() + "de 11 a 14hs y 19 a 23hs.";


    }
}
