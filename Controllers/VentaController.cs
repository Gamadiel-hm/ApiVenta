using ApiVenta.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiVenta.Controllers
{
    [ApiController]
    [Route("api/v1/venta")]
    public class VentaController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpPost("{id:int}/{cantidad:int}")]
        public async Task<ActionResult> Venta(int id, int cantidad)
        {
            Producto producto = await _context.Productos.AsTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (producto is null)
                return BadRequest(id);

            if (producto.Cantidad > cantidad)
            {
                producto.Cantidad = producto.Cantidad - cantidad;
                await _context.SaveChangesAsync();
                return Ok(producto);
            }

            return BadRequest($"La cantidad supera los productos: {cantidad}");

        }
    }
}
