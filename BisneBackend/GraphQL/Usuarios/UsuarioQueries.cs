using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace BisneBackend.GraphQL.Usuarios
{
    [ExtendObjectType("Query")]
    public class UsuarioQueries
    {
        [UseApplicationDbContext]
        public Task<List<Usuario_Registrado>> GetUsuarios([ScopedService] MyDbContext context) =>
           context.Usuarios_Registrados.ToListAsync();

        public Task<Usuario_Registrado> GetUsuarioAsync(
             [ID(nameof(Usuario_Registrado))] int id,
             UsuarioByIdDataLoader dataLoader,
             CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);

        [UseApplicationDbContext]
        public async Task<IReadOnlyList<Tienda>> GetUsuarioTiendasFavAsync(
             [ID(nameof(Usuario_Registrado))] int id,
             [ScopedService] MyDbContext context,
             TiendaByIdDataLoader dataLoader,
             CancellationToken cancellationToken)
        {

            int[] tiendaIds = await context.UsuarioTiendaFavs
                .Where(u => u.usuarioId == id).Select(t => t.tiendaId).ToArrayAsync();

            return await dataLoader.LoadAsync(tiendaIds, cancellationToken);
        }
        [UseApplicationDbContext]
        public async Task<IReadOnlyList<Oferta>> GetUsuarioOfertasFavAsync(
             [ID(nameof(Usuario_Registrado))] int id,
             [ScopedService] MyDbContext context,
             OfertaByIdDataLoader dataLoader,
             CancellationToken cancellationToken)
        {

            int[] ofertaIds = await context.UsuarioOfertaFavs
                .Where(u => u.usuarioId == id).Select(o => o.ofertaId).ToArrayAsync();

            return await dataLoader.LoadAsync(ofertaIds, cancellationToken);
        }

        [UseApplicationDbContext]
        public async Task<Dictionary<Factura,Tienda>> GetUsuarioFacturasAsync(
             [ID(nameof(Usuario_Registrado))] int id,
             [ScopedService] MyDbContext context,
             TiendaByIdDataLoader datatienda,
             CancellationToken cancellationToken)
        {

            var facturas = await context.Facturas
                .Where(t => t.usuarioId == id).ToArrayAsync();
      
            var dic = new Dictionary<Factura,Tienda>();
            foreach (var f in facturas)
            {
                
                var t = await context.FacturaOfertas.Where(a => a.facturaId == f.Id).Select(b => b.ofertaId).FirstOrDefaultAsync();
                if (t != default)
                {
                    var o = await context.Ofertas.FindAsync(t);
                    var tienda = await datatienda.LoadAsync(o.tiendaId, cancellationToken);
                    dic.Add(f, tienda);
                }
                
            }
            return dic;
        }


        [UseApplicationDbContext]
        public async Task<Dictionary<Factura, double>> GetUsuarioFacturaPreciosAsync(
             [ID(nameof(Usuario_Registrado))] int id,
             [ScopedService] MyDbContext context,
             TiendaByIdDataLoader datatienda,
             CancellationToken cancellationToken)
        {

            var facturas = await context.Facturas
                .Where(t => t.usuarioId == id).ToArrayAsync();

            var dic = new Dictionary<Factura, double>();
            foreach (var f in facturas)
            {
                var t = await context.FacturaOfertas.Where(a => a.facturaId == f.Id).ToListAsync();
                if (t.Count() > 0)
                {
                    var monto=t.Sum(b=>b.monto_total);
                    dic.Add(f, monto);
                }
                
            }
            return dic;
        }



        [UseApplicationDbContext]
        public Task<List<AdministradordeTienda>> GetAdministradoresAsync
            ([ScopedService] MyDbContext context) =>
            context.Administradordes.ToListAsync();

        [UseApplicationDbContext]
        public Task<List<Tienda>> GetAdministradorTiendaAsync
            ([ScopedService] MyDbContext context,
            [ID(nameof(Usuario_Registrado))] int id)
        {
            return context.Tiendas.Where(t => t.administradorId == id).ToListAsync();
        }

        [UseApplicationDbContext]

        public async Task<bool> GetValidNameAsync
            ([ScopedService] MyDbContext context,
            string name)
        {
            var names= await context.Usuarios_Registrados.Where(n=>n.nombre == name).ToListAsync();
            return (names.Count == 0);
        }

        public async Task<string> GetValidLoginAsync
            ([ScopedService] MyDbContext context,
            string username, string password)
        {
            var name = await context.Usuarios_Registrados.Where(m=>m.nombre == username).ToListAsync();
            if (name.Count == 0) return "user";
            var pass = name.Where(p => p.password == password).ToList();
            if (pass.Count == 0) return "pass";
            return "ok";
        }



    }
}
