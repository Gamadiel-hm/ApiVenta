using ApiVenta.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiVenta
{
    public static class DataSeeding
    {
        public static void DataSeed(ModelBuilder modelBuilder)
        {
            Producto producto1 = new() { Id = 1, Name = "Procuto1", Precio = 194.34M, Cantidad = 100, DateCreate = DateTime.Now, DateDelete = DateTime.Now, SoftDelete = false };
            Producto producto2 = new() { Id = 2, Name = "Procuto2", Precio = 56.34M, Cantidad = 65, DateCreate = DateTime.Now, DateDelete = DateTime.Now, SoftDelete = false };
            Producto producto3 = new() { Id = 3, Name = "Procuto3", Precio = 15.34M, Cantidad = 20, DateCreate = DateTime.Now, DateDelete = DateTime.Now, SoftDelete = false };
            Codigo codigo1 = new Codigo() { Id = 1, NoCodigo = "Codigo1", ProductoId = producto1.Id };
            Codigo codigo2 = new Codigo() { Id = 2, NoCodigo = "Codigo2", ProductoId = producto1.Id };
            Codigo codigo3 = new Codigo() { Id = 3, NoCodigo = "Codigo3", ProductoId = producto2.Id };
            Codigo codigo4 = new Codigo() { Id = 4, NoCodigo = "Codigo4", ProductoId = producto2.Id };
            Codigo codigo5 = new Codigo() { Id = 5, NoCodigo = "Codigo5", ProductoId = producto3.Id };

            modelBuilder.Entity<Producto>().HasData(producto1, producto2, producto3);
            modelBuilder.Entity<Codigo>().HasData(codigo1, codigo2, codigo3, codigo4, codigo5);
        }
    }
}
