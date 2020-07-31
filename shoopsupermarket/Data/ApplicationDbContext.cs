using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shoopsupermarket.Models;

namespace shoopsupermarket.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SliderConfiguracion> SliderConfiguracion { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<ArticulosOrden> ArticulosOrdenes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=shoopdb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticulosOrden>().HasKey(o => new { o.ORD_ID, o.ART_ID });
            base.OnModelCreating(modelBuilder);
        }
    }
}
