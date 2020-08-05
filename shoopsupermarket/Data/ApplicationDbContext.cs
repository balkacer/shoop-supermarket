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
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            string sqlConLocal = "Server=localhost\\SQLEXPRESS;Database=shoopdb;Trusted_Connection=True;MultipleActiveResultSets=true";
            string sqlConHosting = "Data Source=SQL5063.site4now.net;Initial Catalog=DB_A650B9_shoopdb;User Id=DB_A650B9_shoopdb_admin;Password=DataBase2020@";
            optionsBuilder.UseSqlServer(sqlConHosting);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }        
    }
}
