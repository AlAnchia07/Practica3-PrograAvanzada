using Microsoft.EntityFrameworkCore;
using Practica3.Models;

namespace Practica3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<OrdenServicio> Ordenes { get; set; }
        public DbSet<TipoServicio> TiposServicio { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrdenServicio>()
                .Property(o => o.CostoEstimado)
                .HasPrecision(18, 2);

            // Un cliente con órdenes NO se puede borrar
            builder.Entity<OrdenServicio>()
                .HasOne(o => o.Cliente)
                .WithMany(c => c.Ordenes)
                .HasForeignKey(o => o.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OrdenServicio>()
                .HasOne(o => o.TipoServicio)
                .WithMany(t => t.Ordenes)
                .HasForeignKey(o => o.TipoServicioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Datos iniciales
            builder.Entity<TipoServicio>().HasData(
                new TipoServicio { Id = 1, Nombre = "Diagnóstico" },
                new TipoServicio { Id = 2, Nombre = "Reparación de hardware" },
                new TipoServicio { Id = 3, Nombre = "Cambio de pantalla" },
                new TipoServicio { Id = 4, Nombre = "Mantenimiento preventivo" },
                new TipoServicio { Id = 5, Nombre = "Instalación de software" }
            );
        }
    }
}