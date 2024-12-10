using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _2024_2C_SushiPOP_G1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class DbContext(DbContextOptions<DbContext> options) : IdentityDbContext(options)
{

    public DbSet<_2024_2C_SushiPOP_G1.Models.Contacto> Contacto { get; set; } = default!;

    public DbSet<_2024_2C_SushiPOP_G1.Models.Carrito> Carrito { get; set; } = default!;

    public DbSet<_2024_2C_SushiPOP_G1.Models.CarritoItem> CarritoItem { get; set; } = default!;

    public DbSet<_2024_2C_SushiPOP_G1.Models.Categoria> Categoria { get; set; } = default!;

    public DbSet<_2024_2C_SushiPOP_G1.Models.Cliente> Cliente { get; set; } = default!;

    public DbSet<_2024_2C_SushiPOP_G1.Models.Descuento> Descuento { get; set; } = default!;

    public DbSet<_2024_2C_SushiPOP_G1.Models.Empleado> Empleado { get; set; } = default!;

    public DbSet<_2024_2C_SushiPOP_G1.Models.Pedido> Pedido { get; set; } = default!;

    public DbSet<_2024_2C_SushiPOP_G1.Models.Producto> Producto { get; set; } = default!;

    public DbSet<_2024_2C_SushiPOP_G1.Models.Reclamo> Reclamo { get; set; } = default!;

    public DbSet<_2024_2C_SushiPOP_G1.Models.Reserva> Reserva { get; set; } = default!;
}
