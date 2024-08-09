using ApiVenta.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiVenta
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>().Property(prop => prop.Name)
                .IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Producto>().Property(prop => prop.Precio)
                .IsRequired().HasPrecision(6,2);

            modelBuilder.Entity<Producto>().HasQueryFilter(prop => !prop.SoftDelete);
            DataSeeding.DataSeed(modelBuilder);
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Codigo> Codigos { get; set; }
    }
}
