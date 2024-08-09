using ApiVenta.Dtos;
using ApiVenta.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiVenta.Controllers
{
    [ApiController]
    [Route("api/v1/producto")]
    public class ProductoController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<ProductoDto> listProducts = await _context.Productos
                .Include(nav1 => nav1.Codigos)
                .Select(s => new ProductoDto { Id = s.Id, Name = s.Name, Precio = s.Precio, Codigos = s.Codigos.Select(a => a.NoCodigo).ToList()}).ToListAsync();

            return Ok(listProducts);
        }

        [HttpGet("id/{id:int}")]
        public async Task<ActionResult> GetById([FromRoute]int id)
        {
            ProductoDto productId = await _context.Productos
                .Select(s => new ProductoDto { Id = s.Id, Name = s.Name, Precio = s.Precio, Codigos = s.Codigos.Select(a => a.NoCodigo).ToList() }).FirstOrDefaultAsync(f => f.Id == id);

            if(productId is null)
                    return BadRequest($"Id : {id}");

            return Ok(productId);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ProductoCreateDto createDto )
        {
            Producto producto = new()
            {
                Name = createDto.Name,
                Precio = createDto.Precio,
                Cantidad = createDto.Cantidad,
            };
            try
            {
                producto.DateCreate = DateTime.Now;
                producto.DateDelete = DateTime.Now;
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok(createDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProducById([FromBody] ProductoUpdateDto createUpdateDto)
        {
            Producto productExist = await _context.Productos.AsTracking().FirstOrDefaultAsync(f => f.Id == createUpdateDto.Id);

            if (productExist is null)
                return BadRequest(createUpdateDto.Id);

            productExist.Precio = createUpdateDto.Precio; 
            productExist.Name = createUpdateDto.Name; 

            await _context.SaveChangesAsync();

            return Ok(createUpdateDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> SoftDelete([FromRoute]int id)
        {
            Producto existProduct = await _context.Productos.FirstOrDefaultAsync(f => f.Id == id);
            if(existProduct is null)
                return BadRequest($"Id : {id}");

            existProduct.SoftDelete = true;
            await _context.SaveChangesAsync();

            return Ok(existProduct);
        }
    }
}
