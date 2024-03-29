﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebVendasMVC.Models;

namespace WebVendasMVC.Migrations
{
    [DbContext(typeof(WebVendasMVCContext))]
    partial class WebVendasMVCContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebVendasMVC.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("WebVendasMVC.Models.Vendas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data_Venda");

                    b.Property<int>("Status");

                    b.Property<double>("ValVendas");

                    b.Property<int?>("VendedoresId");

                    b.HasKey("ID");

                    b.HasIndex("VendedoresId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("WebVendasMVC.Models.Vendedores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentId");

                    b.Property<DateTime>("Dt_aniversario");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<double>("SalarioBase");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("WebVendasMVC.Models.Vendas", b =>
                {
                    b.HasOne("WebVendasMVC.Models.Vendedores", "Vendedores")
                        .WithMany("listaVendas")
                        .HasForeignKey("VendedoresId");
                });

            modelBuilder.Entity("WebVendasMVC.Models.Vendedores", b =>
                {
                    b.HasOne("WebVendasMVC.Models.Department", "Department")
                        .WithMany("vendedores")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
