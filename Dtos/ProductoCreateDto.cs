using ApiVenta.Entities;

namespace ApiVenta.Dtos
{
    public class ProductoCreateDto
    {
        public string Name { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
