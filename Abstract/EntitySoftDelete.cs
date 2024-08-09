namespace ApiVenta.Abstract
{
    public abstract class EntitySoftDelete
    {
        public bool SoftDelete { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateDelete { get; set; }
    }
}
