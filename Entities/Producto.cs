using ApiVenta.Abstract;

namespace ApiVenta.Entities
{
    public sealed class Producto : EntitySoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public List<Codigo> Codigos { get; set; }
    }
}
