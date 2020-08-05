using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }
        public DbSet<Estado> Estados { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer("Server=LAPTOP-9IB9T0EQ\\MYSERVER;Database=shoopdb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetallePedido>().HasKey(o => new { o.ORD_ID, o.ART_ID });

            modelBuilder.Entity<Proveedor>().HasData(new Proveedor { ID = 2, NAME = "Santal", PHONE1 = "8297576437" });
            modelBuilder.Entity<Categoria>().HasData(new Categoria { ID = 2, CAT = "Comida" });
            modelBuilder.Entity<Articulo>().HasData(new Articulo { ID = 2, DESC = "Jugo de Manzana", PRE_VENT = 15, PRE_COMP = 15, STOCK = 20, IMG = "https://res.cloudinary.com/almacendo/image/upload/v1569273056/Jugos/Jugo-Santal-Sabor-Manzana_-200ml-Caja-_24-uds_-Turn.jpg", PROV_ID = 1, CAT_ID = 1 });

            base.OnModelCreating(modelBuilder);
        }

        
    }
}
