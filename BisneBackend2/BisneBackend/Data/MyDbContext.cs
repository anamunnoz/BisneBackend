using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisneBackend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BisneBackend.Data
{
    public class MyDbContext : DbContext
    {
       

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Tienda> Tiendas { get; set; } = default!;
        public DbSet<AdministradordeTienda> Administradordes { get; set; } = default!;
        public DbSet<Categoria> Categorias { get; set; } = default!;
        public DbSet<Factura> Facturas { get; set; } = default!;
        public DbSet<Ip> Ips { get; set; } = default!;
        public DbSet<Oferta> Ofertas { get; set; } = default!;
        public DbSet<Producto> Productos { get; set; } = default!;
        public DbSet<Servicio> Servicios { get; set; } = default!;
        public DbSet<Usuario_Registrado> Usuarios_Registrados { get; set; } = default!;
        public DbSet<UsuarioIp> UsuarioIps { get; set; } = default!;
        public DbSet<UsuarioOfertaComentario> UsuarioOfertaComentarios { get; set; } = default!;
        public DbSet<UsuarioOfertaValoracion> UsuarioOfertaValoraciones { get; set; } = default!;
        public DbSet<UsuarioTiendaComentario> UsuarioTiendaComentarios { get; set; } = default!;
        public DbSet<UsuarioTiendaFav> UsuarioTiendaFavs { get; set; } = default!;
        public DbSet<UsuarioOfertaFav> UsuarioOfertaFavs { get; set; } = default!;
        public DbSet<UsuarioTiendaValoracion> UsuarioTiendaValoraciones { get; set; } = default!;
        public DbSet<FacturaOferta> FacturaOfertas { get; set; } = default!;
        public DbSet<OfertaCategoria> OfertaCategorias { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //setear las llaves de tablas cuya llave primaria es una tupla
            modelBuilder.Entity<UsuarioIp>().HasKey(ui => new { ui.usuarioRegistradoId, ui.ipId });
            modelBuilder.Entity<FacturaOferta>().HasKey(fo => new { fo.facturaId, fo.ofertaId });
            modelBuilder.Entity<OfertaCategoria>().HasKey(oc => new { oc.ofertaId, oc.categoriaId });
            modelBuilder.Entity<UsuarioOfertaComentario>().HasKey(uo => new { uo.usuarioId, uo.ofertaId });
            modelBuilder.Entity<UsuarioOfertaFav>().HasKey(uo => new { uo.usuarioId, uo.ofertaId });
            modelBuilder.Entity<UsuarioOfertaValoracion>().HasKey(uo => new { uo.usuarioId, uo.ofertaId });
            modelBuilder.Entity<UsuarioTiendaComentario>().HasKey(ut => new { ut.usuarioId, ut.tiendaId });
            modelBuilder.Entity<UsuarioTiendaFav>().HasKey(ut => new { ut.usuarioId, ut.tiendaId });
            modelBuilder.Entity<UsuarioTiendaValoracion>().HasKey(ut => new { ut.usuarioId, ut.tiendaId });
            //configurarl=listas de las tablas muchos muchos
            modelBuilder.Entity<UsuarioIp>().HasOne(ui => ui.usuarioRegistrado).WithMany(u => u.UsuarioIps).HasForeignKey(ui => ui.usuarioRegistradoId);
            modelBuilder.Entity<UsuarioIp>().HasOne(ui => ui.ip).WithMany(i => i.UsuarioIps).HasForeignKey(ui => ui.ipId);
            modelBuilder.Entity<FacturaOferta>().HasOne(fo => fo.factura).WithMany(f => f.FacturaOfertas).HasForeignKey(fo => fo.facturaId);
            modelBuilder.Entity<FacturaOferta>().HasOne(fo => fo.oferta).WithMany(o => o.FacturaOfertas).HasForeignKey(fo => fo.ofertaId);
            modelBuilder.Entity<OfertaCategoria>().HasOne(oc => oc.oferta).WithMany(o => o.OfertaCategorias).HasForeignKey(oc => oc.ofertaId);
            modelBuilder.Entity<OfertaCategoria>().HasOne(oc => oc.categoria).WithMany(c => c.OfertaCategorias).HasForeignKey(oc => oc.categoriaId);
            modelBuilder.Entity<UsuarioOfertaComentario>().HasOne(uo => uo.usuario).WithMany(u => u.usuarioOfertaComentarios).HasForeignKey(uo => uo.usuarioId);
            modelBuilder.Entity<UsuarioOfertaComentario>().HasOne(uo => uo.oferta).WithMany(o => o.usuarioOfertaComentarios).HasForeignKey(uo => uo.ofertaId);
            modelBuilder.Entity<UsuarioOfertaValoracion>().HasOne(uo => uo.usuario).WithMany(u => u.usuarioOfertaValoraciones).HasForeignKey(uo => uo.usuarioId);
            modelBuilder.Entity<UsuarioOfertaValoracion>().HasOne(uo => uo.oferta).WithMany(o => o.usuarioOfertaValoraciones).HasForeignKey(uo => uo.ofertaId);
            modelBuilder.Entity<UsuarioTiendaComentario>().HasOne(ut => ut.usuario).WithMany(u => u.usuarioTiendaComentarios).HasForeignKey(ut => ut.usuarioId);
            modelBuilder.Entity<UsuarioTiendaComentario>().HasOne(ut => ut.tienda).WithMany(t => t.usuarioTiendaComentarios).HasForeignKey(ut => ut.tiendaId);
            modelBuilder.Entity<UsuarioTiendaFav>().HasOne(ut => ut.usuario).WithMany(u => u.usuarioTiendaFavs).HasForeignKey(ut => ut.usuarioId);
            modelBuilder.Entity<UsuarioTiendaFav>().HasOne(ut => ut.tienda).WithMany(t => t.usuarioTiendaFavs).HasForeignKey(ut => ut.tiendaId);
            modelBuilder.Entity<UsuarioTiendaValoracion>().HasOne(ut => ut.usuario).WithMany(u => u.usuarioTiendaValoraciones).HasForeignKey(ut => ut.usuarioId);
            modelBuilder.Entity<UsuarioTiendaValoracion>().HasOne(ut => ut.tienda).WithMany(t => t.usuarioTiendaValoraciones).HasForeignKey(ut => ut.tiendaId);
        }
    }
}
