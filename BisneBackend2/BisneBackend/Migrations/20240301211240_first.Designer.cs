﻿// <auto-generated />
using System;
using BisneBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BisneBackend.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240301211240_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BisneBackend.Data.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("padreId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("padreId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("direccion_envio")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateOnly>("fecha")
                        .HasColumnType("date");

                    b.Property<int>("usuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("usuarioId");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.FacturaOferta", b =>
                {
                    b.Property<int>("facturaId")
                        .HasColumnType("integer");

                    b.Property<int>("ofertaId")
                        .HasColumnType("integer");

                    b.Property<double>("cantidad")
                        .HasColumnType("double precision");

                    b.Property<double>("monto_total")
                        .HasColumnType("double precision");

                    b.HasKey("facturaId", "ofertaId");

                    b.HasIndex("ofertaId");

                    b.ToTable("FacturaOfertas");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Ip", b =>
                {
                    b.Property<string>("ipId")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("ipId");

                    b.ToTable("Ip");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Oferta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("cantidad")
                        .HasColumnType("integer");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("descuento")
                        .HasColumnType("integer");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("precio")
                        .HasColumnType("integer");

                    b.Property<int>("tiendaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("tiendaId");

                    b.ToTable("Oferta");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.OfertaCategoria", b =>
                {
                    b.Property<int>("ofertaId")
                        .HasColumnType("integer");

                    b.Property<int>("categoriaId")
                        .HasColumnType("integer");

                    b.HasKey("ofertaId", "categoriaId");

                    b.HasIndex("categoriaId");

                    b.ToTable("OfertaCategorias");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Tienda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageURL")
                        .HasColumnType("text");

                    b.Property<int>("administradorId")
                        .HasColumnType("integer");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("horario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("linkExtra")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("linkFacebook")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("linkInstagram")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("numeroTelefono")
                        .HasColumnType("integer");

                    b.Property<int?>("numeroWhatsapp")
                        .HasColumnType("integer");

                    b.Property<string>("usuarioTelegram")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("administradorId");

                    b.ToTable("Tienda");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Usuario_Registrado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.HasKey("Id");

                    b.ToTable("UsuarioRegistrado");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.UsuarioIp", b =>
                {
                    b.Property<int>("usuarioRegistradoId")
                        .HasColumnType("integer");

                    b.Property<string>("ipId")
                        .HasColumnType("character varying(255)");

                    b.HasKey("usuarioRegistradoId", "ipId");

                    b.HasIndex("ipId");

                    b.ToTable("UsuarioIps");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.UsuarioOfertaComentario", b =>
                {
                    b.Property<int>("usuarioId")
                        .HasColumnType("integer");

                    b.Property<int>("ofertaId")
                        .HasColumnType("integer");

                    b.Property<string>("comentario")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.HasKey("usuarioId", "ofertaId");

                    b.HasIndex("ofertaId");

                    b.ToTable("UsuarioOfertaComentarios");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.UsuarioOfertaValoracion", b =>
                {
                    b.Property<int>("usuarioId")
                        .HasColumnType("integer");

                    b.Property<int>("ofertaId")
                        .HasColumnType("integer");

                    b.Property<int>("valoracion")
                        .HasColumnType("integer");

                    b.HasKey("usuarioId", "ofertaId");

                    b.HasIndex("ofertaId");

                    b.ToTable("UsuarioOfertaValoraciones");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.UsuarioTiendaComentario", b =>
                {
                    b.Property<int>("usuarioId")
                        .HasColumnType("integer");

                    b.Property<int>("tiendaId")
                        .HasColumnType("integer");

                    b.Property<string>("comentario")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.HasKey("usuarioId", "tiendaId");

                    b.HasIndex("tiendaId");

                    b.ToTable("UsuarioTiendaComentarios");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.UsuarioTiendaFav", b =>
                {
                    b.Property<int>("usuarioId")
                        .HasColumnType("integer");

                    b.Property<int>("tiendaId")
                        .HasColumnType("integer");

                    b.HasKey("usuarioId", "tiendaId");

                    b.HasIndex("tiendaId");

                    b.ToTable("UsuarioTiendaFavs");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.UsuarioTiendaValoracion", b =>
                {
                    b.Property<int>("usuarioId")
                        .HasColumnType("integer");

                    b.Property<int>("tiendaId")
                        .HasColumnType("integer");

                    b.Property<int>("valoracion")
                        .HasColumnType("integer");

                    b.HasKey("usuarioId", "tiendaId");

                    b.HasIndex("tiendaId");

                    b.ToTable("UsuarioTiendaValoraciones");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.AdministradordeTienda", b =>
                {
                    b.HasBaseType("BisneBackend.Data.Models.Usuario_Registrado");

                    b.ToTable("Administrador");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Producto", b =>
                {
                    b.HasBaseType("BisneBackend.Data.Models.Oferta");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("marca")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<double>("peso")
                        .HasColumnType("double precision");

                    b.Property<double>("volumen")
                        .HasColumnType("double precision");

                    b.ToTable("Prodcuto");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Servicio", b =>
                {
                    b.HasBaseType("BisneBackend.Data.Models.Oferta");

                    b.Property<string>("horario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.ToTable("Servicio");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Categoria", b =>
                {
                    b.HasOne("BisneBackend.Data.Models.Categoria", "padre")
                        .WithMany()
                        .HasForeignKey("padreId");

                    b.Navigation("padre");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Factura", b =>
                {
                    b.HasOne("BisneBackend.Data.Models.Usuario_Registrado", "usuario")
                        .WithMany("facturas")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.FacturaOferta", b =>
                {
                    b.HasOne("BisneBackend.Data.Models.Factura", "factura")
                        .WithMany("FacturaOfertas")
                        .HasForeignKey("facturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BisneBackend.Data.Models.Oferta", "oferta")
                        .WithMany("FacturaOfertas")
                        .HasForeignKey("ofertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("factura");

                    b.Navigation("oferta");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Oferta", b =>
                {
                    b.HasOne("BisneBackend.Data.Models.Tienda", "tienda")
                        .WithMany("ofertas")
                        .HasForeignKey("tiendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tienda");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.OfertaCategoria", b =>
                {
                    b.HasOne("BisneBackend.Data.Models.Categoria", "categoria")
                        .WithMany("OfertaCategorias")
                        .HasForeignKey("categoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BisneBackend.Data.Models.Oferta", "oferta")
                        .WithMany("OfertaCategorias")
                        .HasForeignKey("ofertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoria");

                    b.Navigation("oferta");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Tienda", b =>
                {
                    b.HasOne("BisneBackend.Data.Models.AdministradordeTienda", "administrador")
                        .WithMany()
                        .HasForeignKey("administradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("administrador");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.UsuarioIp", b =>
                {
                    b.HasOne("BisneBackend.Data.Models.Ip", "ip")
                        .WithMany("UsuarioIps")
                        .HasForeignKey("ipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BisneBackend.Data.Models.Usuario_Registrado", "usuarioRegistrado")
                        .WithMany("UsuarioIps")
                        .HasForeignKey("usuarioRegistradoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ip");

                    b.Navigation("usuarioRegistrado");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.UsuarioOfertaComentario", b =>
                {
                    b.HasOne("BisneBackend.Data.Models.Oferta", "oferta")
                        .WithMany("usuarioOfertaComentarios")
                        .HasForeignKey("ofertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BisneBackend.Data.Models.Usuario_Registrado", "usuario")
                        .WithMany("usuarioOfertaComentarios")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("oferta");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.UsuarioOfertaValoracion", b =>
                {
                    b.HasOne("BisneBackend.Data.Models.Oferta", "oferta")
                        .WithMany("usuarioOfertaValoraciones")
                        .HasForeignKey("ofertaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BisneBackend.Data.Models.Usuario_Registrado", "usuario")
                        .WithMany("usuarioOfertaValoraciones")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("oferta");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.UsuarioTiendaComentario", b =>
                {
                    b.HasOne("BisneBackend.Data.Models.Tienda", "tienda")
                        .WithMany("usuarioTiendaComentarios")
                        .HasForeignKey("tiendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BisneBackend.Data.Models.Usuario_Registrado", "usuario")
                        .WithMany("usuarioTiendaComentarios")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tienda");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.UsuarioTiendaFav", b =>
                {
                    b.HasOne("BisneBackend.Data.Models.Tienda", "tienda")
                        .WithMany("usuarioTiendaFavs")
                        .HasForeignKey("tiendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BisneBackend.Data.Models.Usuario_Registrado", "usuario")
                        .WithMany("usuarioTiendaFavs")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tienda");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.UsuarioTiendaValoracion", b =>
                {
                    b.HasOne("BisneBackend.Data.Models.Tienda", "tienda")
                        .WithMany("usuarioTiendaValoraciones")
                        .HasForeignKey("tiendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BisneBackend.Data.Models.Usuario_Registrado", "usuario")
                        .WithMany("usuarioTiendaValoraciones")
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tienda");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.AdministradordeTienda", b =>
                {
                    b.HasOne("BisneBackend.Data.Models.Usuario_Registrado", null)
                        .WithOne()
                        .HasForeignKey("BisneBackend.Data.Models.AdministradordeTienda", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Producto", b =>
                {
                    b.HasOne("BisneBackend.Data.Models.Oferta", null)
                        .WithOne()
                        .HasForeignKey("BisneBackend.Data.Models.Producto", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Servicio", b =>
                {
                    b.HasOne("BisneBackend.Data.Models.Oferta", null)
                        .WithOne()
                        .HasForeignKey("BisneBackend.Data.Models.Servicio", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Categoria", b =>
                {
                    b.Navigation("OfertaCategorias");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Factura", b =>
                {
                    b.Navigation("FacturaOfertas");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Ip", b =>
                {
                    b.Navigation("UsuarioIps");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Oferta", b =>
                {
                    b.Navigation("FacturaOfertas");

                    b.Navigation("OfertaCategorias");

                    b.Navigation("usuarioOfertaComentarios");

                    b.Navigation("usuarioOfertaValoraciones");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Tienda", b =>
                {
                    b.Navigation("ofertas");

                    b.Navigation("usuarioTiendaComentarios");

                    b.Navigation("usuarioTiendaFavs");

                    b.Navigation("usuarioTiendaValoraciones");
                });

            modelBuilder.Entity("BisneBackend.Data.Models.Usuario_Registrado", b =>
                {
                    b.Navigation("UsuarioIps");

                    b.Navigation("facturas");

                    b.Navigation("usuarioOfertaComentarios");

                    b.Navigation("usuarioOfertaValoraciones");

                    b.Navigation("usuarioTiendaComentarios");

                    b.Navigation("usuarioTiendaFavs");

                    b.Navigation("usuarioTiendaValoraciones");
                });
#pragma warning restore 612, 618
        }
    }
}
