using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2024_2C_SushiPOP_G1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace _2024_2C_SushiPOP_G1.Controllers
{
    public class PedidosController : Controller
    {
        private readonly DbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public PedidosController(DbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Pedidos
        [Authorize(Roles = "CLIENTE,EMPLEADO")]
        public async Task<IActionResult> Index()
        {
            var dbContext = _context.Pedido.Include(p => p.Carrito);
            return View(await dbContext.ToListAsync());
        }

        // GET: Pedidos/Details/5
        [Authorize(Roles = "CLIENTE,EMPLEADO")]
        public async Task<IActionResult> Details(int? id)
        {
            var usuarioLogueado = await _userManager.GetUserAsync(User);
            Cliente cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Email == usuarioLogueado.Email);

            Carrito carrito = await _context.Carrito
                    .Include(c => c.Cliente)
                    .Include(c => c.CarritoItems)
                    .ThenInclude(ci => ci.Producto)
                    .FirstOrDefaultAsync(c => !c.Procesando && c.Cliente.Email == usuarioLogueado.Email);
            if (carrito == null) {
                return NotFound();
            }
            decimal subtotal = carrito.CarritoItems.Sum(x => x.PreiocUnitarioConDescuento * x.Cantidad);
            // Si los pedidos del cliente son mas de 10 el envio es gratis sino vale 80
            decimal listaCarritos = await _context.Carrito.Where(c=>c.Pedido != null && c.ClienteId == cliente.Id && c.Pedido.FechaDeCompra >= DateTime.Now.AddMonths(-1) && c.Pedido.Estado).CountAsync();
            decimal costeEnvio = 80;
            if (listaCarritos > 10) {
                costeEnvio = 0;
            }
            // FechaCompra >= DateTime.Now.AddMonth(-1)
            
            DetallePedidoViewModel PedidoWM = new()
            {
                Cliente = cliente.Nombre + " " + cliente.Apellido,
                SubTotal = subtotal,
                CostoEnvio = costeEnvio,
                Total = subtotal + costeEnvio,
            };

            return View(PedidoWM);
        }


        public async Task<IActionResult> ConfirmarPedido()
        {
            // Detalle carrito
            IdentityUser usuarioLogueado = await _userManager.GetUserAsync(User);

            Carrito carrito = await _context.Carrito
                .Include(c => c.Cliente)
                .Include(c => c.CarritoItems)
                .ThenInclude(ci => ci.Producto)
                .FirstOrDefaultAsync(c => !c.Procesando && c.Cliente.Email == usuarioLogueado.Email);

            decimal subtotal = carrito.CarritoItems.Sum(x => x.PreiocUnitarioConDescuento * x.Cantidad);
            decimal gastoEnvio = 80;
            // Fin detalle carrito


            // Paso 1: crear el pedido
            Pedido pedido = new()
            {
                SubTotal = subtotal,
                GastoEnvio = gastoEnvio,
                Total = subtotal + gastoEnvio,
                FechaDeCompra = DateTime.Now,
                CarritoId = carrito.Id
            };
            _context.Add(pedido);
            await _context.SaveChangesAsync();


            // Paso 2: marcar el carrito como procesado
            carrito.Procesando = true;
            _context.Update(carrito);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index", "Home");
        }

    }
}
