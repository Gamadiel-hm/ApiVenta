namespace ApiVenta.Entities
{
    public class Codigo
    {
        public int Id { get; set; }
        public string NoCodigo { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
