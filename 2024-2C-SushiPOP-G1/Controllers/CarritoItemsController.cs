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
    public class CarritoItemsController : Controller
    {
        private readonly DbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CarritoItemsController(DbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CarritoItems
        [Authorize(Roles = "CLIENTE")]
        public async Task<IActionResult> Index()
        {
            var dbContext = _context.CarritoItem.Include(c => c.Carrito).Include(c => c.Producto);
            return View(await dbContext.ToListAsync());
        }
        // GET: CarritoItems/Create
        [Authorize(Roles = "CLIENTE")]
        public IActionResult Create()
        {
            ViewData["CarritoId"] = new SelectList(_context.Carrito, "Id", "Id");
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Nombre");
            return View();
        }

        // GET: CarritoItems/Details/5
        [Authorize(Roles = "CLIENTE")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carritoItem = await _context.CarritoItem
                .Include(c => c.Carrito)
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carritoItem == null)
            {
                return NotFound();
            }

            return View(carritoItem);
        }


        // POST: CarritoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "CLIENTE")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,Cantidad")] ItemViewModel carritoItem)
        {
            if (ModelState.IsValid)
            {
                Producto producto = await _context.Producto.FindAsync(carritoItem.ProductoId);

                if (producto.Stock < carritoItem.Cantidad)
                {
                    return NotFound();
                }

                var usuarioLogueado = await _userManager.GetUserAsync(User);
                Cliente cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Email == usuarioLogueado.Email);

                Carrito carrito = await _context.Carrito
                    .Include(c => c.Cliente)
                    .Include(c => c.CarritoItems)
                    .ThenInclude(ci => ci.Producto)
                    .FirstOrDefaultAsync(c => !c.Procesando && c.Cliente.Email == usuarioLogueado.Email);

                // Veo si el cliente tiene un carrito
                if (carrito == null)
                {
                    // Creamos el carrito
                    carrito = new();
                    carrito.Procesando = false;
                    carrito.ClienteId = cliente.Id;
                    carrito.CarritoItems = [];

                    _context.Add(carrito);
                    await _context.SaveChangesAsync();

                    // Creo el item
                    CarritoItem item = new();
                    item.PreiocUnitarioConDescuento = producto.Precio;
                    item.Cantidad = carritoItem.Cantidad;
                    item.ProductoId = producto.Id;
                    item.CarritoId = carrito.Id;

                    _context.Add(item);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    // Buscar si el producto está en el carrito
                    CarritoItem itemBuscado = carrito.CarritoItems.FirstOrDefault(ci => ci.ProductoId == carritoItem.ProductoId);

                    if (itemBuscado == null)
                    {
                        decimal precio = producto.Precio;
                        int dia = (int)DateTime.Today.DayOfWeek;

                        var descuentoBuscado = await _context.Descuento.Where(d=> d.Dia==dia && d.EstaActivo && d.ProductoId==producto.Id).FirstOrDefaultAsync();

                        if (descuentoBuscado != null)
                        {
                            precio = precio - precio * descuentoBuscado.Porcentaje / 100;//Modificar añadiendo el tope

                        }


                        itemBuscado = new();
                        itemBuscado.PreiocUnitarioConDescuento =precio;
                        itemBuscado.Cantidad = carritoItem.Cantidad;
                        itemBuscado.ProductoId = producto.Id;
                        itemBuscado.CarritoId = carrito.Id;

                        _context.Add(itemBuscado);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        itemBuscado.Cantidad += carritoItem.Cantidad;
                        _context.Update(itemBuscado);
                        await _context.SaveChangesAsync();
                    }
                }

                // Modificar stock del producto
                producto.Stock -= carritoItem.Cantidad;
                _context.Update(producto);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "CarritoItems");
        }

        // GET: CarritoItems/Edit/5
        [Authorize(Roles = "CLIENTE")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carritoItem = await _context.CarritoItem.FindAsync(id);
            if (carritoItem == null)
            {
                return NotFound();
            }
            ViewData["CarritoId"] = new SelectList(_context.Carrito, "Id", "Id", carritoItem.CarritoId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Id", carritoItem.ProductoId);
            return View(carritoItem);
        }

        // POST: CarritoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "CLIENTE")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PreiocUnitarioConDescuento,Cantidad,CarritoId,ProductoId")] CarritoItem carritoItem)
        {
            if (id != carritoItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carritoItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarritoItemExists(carritoItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarritoId"] = new SelectList(_context.Carrito, "Id", "Id", carritoItem.CarritoId);
            ViewData["ProductoId"] = new SelectList(_context.Producto, "Id", "Id", carritoItem.ProductoId);
            return View(carritoItem);
        }

        // GET: CarritoItems/Delete/5
        [Authorize(Roles = "CLIENTE")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carritoItem = await _context.CarritoItem
                .Include(c => c.Carrito)
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carritoItem == null)
            {
                return NotFound();
            }

            return View(carritoItem);
        }

        // POST: CarritoItems/Delete/5
        [Authorize(Roles = "CLIENTE")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carritoItem = await _context.CarritoItem.FindAsync(id);
            if (carritoItem != null)
            {
                _context.CarritoItem.Remove(carritoItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarritoItemExists(int id)
        {
            return _context.CarritoItem.Any(e => e.Id == id);
        }
    }
}
