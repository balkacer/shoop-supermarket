﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shoopsupermarket.Data;

namespace shoopsupermarket.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200720030407_Roles2Migration")]
    partial class Roles2Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("shoopsupermarket.Models.Articulo", b =>
                {
                    b.Property<int>("ARTI_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DESC")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<double>("PRE_COMP")
                        .HasColumnType("REAL");

                    b.Property<double>("PRE_VENT")
                        .HasColumnType("REAL");

                    b.Property<int>("PROVRefId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("STOCK")
                        .HasColumnType("INTEGER");

                    b.HasKey("ARTI_ID");

                    b.HasIndex("PROVRefId");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("shoopsupermarket.Models.Proveedor", b =>
                {
                    b.Property<int>("PROV_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("PHONE1")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.Property<string>("PHONE2")
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.HasKey("PROV_ID");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("shoopsupermarket.Models.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rol")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("shoopsupermarket.Models.Articulo", b =>
                {
                    b.HasOne("shoopsupermarket.Models.Proveedor", "PROV")
                        .WithMany("Articulos")
                        .HasForeignKey("PROVRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
