using ApiVenta.Dtos;
using ApiVenta.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiVenta.Controllers
{
    [ApiController]
    [Route("api/v1/codigo")]
    public class CodigoController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<CodigoDto> codigos = await _context.Codigos
                .Select(s => new CodigoDto { Id = s.Id, NoCodigo = s.NoCodigo}).ToListAsync();

            return Ok(codigos);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CodigoCreateDto codigoCreateDto)
        {
            Codigo codigo = new()
            {
                NoCodigo = codigoCreateDto.NoCodigo, ProductoId = codigoCreateDto.ProdcutoId
            };

            try
            {
                _context.Codigos.Add(codigo);
                await _context.SaveChangesAsync();

                return Ok(codigoCreateDto);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
