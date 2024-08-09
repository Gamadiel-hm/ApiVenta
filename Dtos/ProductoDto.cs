using ApiVenta.Entities;

namespace ApiVenta.Dtos
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CodigoEnum CodigoEnum { get; set; }
        public decimal Precio { get; set; }
        public List<string> Codigos { get; set; }
    }
}
