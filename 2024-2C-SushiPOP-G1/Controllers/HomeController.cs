using _2024_2C_SushiPOP_G1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Cryptography;


namespace _2024_2C_SushiPOP_G1.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, DbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;

        }


        public async Task<IActionResult> Index()
        {

            if (!_roleManager.RoleExistsAsync("ADMIN").GetAwaiter().GetResult())
            {

                _roleManager.CreateAsync(new IdentityRole("ADMIN")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("EMPLEADO")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("CLIENTE")).GetAwaiter().GetResult();

                IdentityUser user = new();
                user = new();
                user.Email = user.UserName = "admin@ort.edu.ar";
                IdentityResult result = await _userManager.CreateAsync(user, "Password1!");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "ADMIN");
                }
                user = new();
                user.Email = user.UserName = "empleado@ort.edu.ar";
                IdentityResult resultadoo = await _userManager.CreateAsync(user, "Password1!");
                if (resultadoo.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "EMPLEADO");
                }

            }


            int dia = (int)DateTime.Today.DayOfWeek;

            var descuentoBuscado = await _context.Descuento
                .Include(d => d.Producto)
                .Where(d => d.EstaActivo && d.Dia == dia)
                .FirstOrDefaultAsync();

            String horario = String.Empty;

            if (dia > 0 && dia < 5) {
                horario = HomeViewModel.HorarioSemana;
            } else if (dia >= 5 || dia <= 7)
            {
                horario = HomeViewModel.HorarioFinde;
            }

            String mensaje = String.Empty;

            if (descuentoBuscado != null) {
                mensaje = "Hoy " + dia + ". Ahorra un " + descuentoBuscado.Porcentaje + " en " + descuentoBuscado.Producto!.Nombre + ".";
            } else {
                mensaje = "Hoy es " + dia + ". Disfrutá del mejor sushi #EnCasa con amigos";

            }

            //Crear view model HomeViewModel

            HomeViewModel model = new()
            {
                Mensaje = mensaje,
                Horario = horario
            };

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
