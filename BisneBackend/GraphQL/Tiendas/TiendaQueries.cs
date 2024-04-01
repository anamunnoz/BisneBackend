using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;


namespace BisneBackend.GraphQL.Tiendas
{
    [ExtendObjectType("Query")]
    public class TiendaQueries
    {
        //get all
        
        
        [UseApplicationDbContext]
        public Task<List<Tienda>> GetTiendas([ScopedService] MyDbContext context,string ip) =>
            context.Tiendas.ToListAsync();
        

        //get by id

        public Task<Tienda> GetTiendaAsync(
             [ID(nameof(Tienda))] int id,
             TiendaByIdDataLoader dataLoader,
             CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);



        [UseApplicationDbContext]
        public async Task<IReadOnlyList<Oferta>> GetTiendaOfertasAsync(
             [ID(nameof(Tienda))] int id,
             [ScopedService] MyDbContext context,
             OfertaByIdDataLoader dataLoader,
             CancellationToken cancellationToken)
        {

            int[] ofertaIds = await context.Ofertas
                .Where(t => t.tiendaId == id).Select(o => o.Id).ToArrayAsync();

            return await dataLoader.LoadAsync(ofertaIds, cancellationToken);
        }

        [UseApplicationDbContext]
        public async Task<Dictionary<Factura,Usuario_Registrado>> GetTiendaFacturasAsync(
             [ID(nameof(Tienda))] int id,
             [ScopedService] MyDbContext context,
             FacturaByIdByDataLoader dataLoader,
             UsuarioByIdDataLoader dataLoaderuser,
             CancellationToken cancellationToken)
        {

            int[] facturaIds = await context.Ofertas
                .Where(t => t.tiendaId == id)
                .Include(s => s.FacturaOfertas)
                .SelectMany(s => s.FacturaOfertas.Select(t => t.facturaId)).ToArrayAsync();

            var dic = new Dictionary<Factura, Usuario_Registrado>();
            foreach (var f in facturaIds)
            {
                var factura = await dataLoader.LoadAsync(f, cancellationToken);
                var user = await dataLoaderuser.LoadAsync(factura.usuarioId, cancellationToken);
                dic.Add(factura, user);
            }

            return dic;
        }


        [UseApplicationDbContext]
        public async Task<Dictionary<Factura, double>> GetTiendaFacturaPreciosAsync(
             [ID(nameof(Tienda))] int id,
             [ScopedService] MyDbContext context,
             FacturaByIdByDataLoader dataLoader,
             UsuarioByIdDataLoader dataLoaderuser,
             CancellationToken cancellationToken)
        {

            int[] facturaIds = await context.Ofertas
                .Where(t => t.tiendaId == id)
                .Include(s => s.FacturaOfertas)
                .SelectMany(s => s.FacturaOfertas.Select(t => t.facturaId)).ToArrayAsync();

            var dic = new Dictionary<Factura, double>();
            foreach (var f in facturaIds)
            {
                var factura = await dataLoader.LoadAsync(f, cancellationToken);
                var t = await context.FacturaOfertas.Where(a => a.facturaId == f).ToListAsync();
                if (t.Count() > 0)
                {
                    var monto = t.Sum(b => b.monto_total);
                    dic.Add(factura, monto);
                }
                
            }

            return dic;
        }



        [UseApplicationDbContext]
        public async Task<Categoria> GetTiendaCategoriaAsync(
             [ID(nameof(Tienda))] int id,
             [ScopedService] MyDbContext context,
             CategoriaByIdDataLoader dataLoader,
             CancellationToken cancellationToken)
        {

            var ofertas = await context.Ofertas
                .Where(o => o.tiendaId == id).ToListAsync();
            if (ofertas.Count == 0)
            {
                Categoria categoria = new Categoria();
                categoria.nombre = "";
                categoria.Id = -1;
                return categoria;
            }
            var categoriaMasFrecuente = ofertas
                .GroupBy(o => o.categoriaId)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();


            return await dataLoader.LoadAsync(categoriaMasFrecuente, cancellationToken);
        }

        [UseApplicationDbContext]
        public async Task<List<Tienda>> GetTiendaNombreAsync(
             string nombre,
             [ScopedService] MyDbContext context)
        {

            var tiendas = await context.Tiendas
                .Where(t => t.nombre.ToLower().Contains(nombre.ToLower())).ToListAsync();


            return tiendas;
        }

        [UseApplicationDbContext]
        public async Task<double> GetTiendaValoracionAsync(
             [ID(nameof(Tienda))] int id,
             [ScopedService] MyDbContext context)
        {
            var x = await context.UsuarioTiendaValoraciones.Where(t => t.tiendaId == id).ToListAsync();
            if(x.Count==0) return 0;
            return x.Average(v => v.valoracion);


        }

        [UseApplicationDbContext]
        public async Task<List<string[]>> GetTiendaComentarioAsync(
             [ID(nameof(Tienda))] int id,
             UsuarioByIdDataLoader dataloader,
             [ScopedService] MyDbContext context,
             CancellationToken cancellationToken)
        {
            
            List<string[]> usuarioComentario = new List<string[]>();
            var comm= await context.UsuarioTiendaComentarios.ToListAsync();
            foreach (var x in comm)
            {
                if(x.tiendaId == id)
                {
                    var usuario = await dataloader.LoadAsync(x.usuarioId, cancellationToken);
                    string[] info = new string[3] {usuario.nombre,usuario.ImageURL="", x.comentario};
                    usuarioComentario.Add(info);
                }

            }
            
            return usuarioComentario;
        }

        [UseApplicationDbContext]
        public async Task<bool> GetVerificarTiendaComentarioAsync(
             [ID(nameof(Usuario_Registrado))] int usuarioId,
             [ID(nameof(Tienda))] int tiendaId,
             [ScopedService] MyDbContext context)
        {
            var verificacion = await context.UsuarioTiendaComentarios
                 .Where(u => u.usuarioId == usuarioId)
                 .Where(t => t.tiendaId == tiendaId)
                 .ToListAsync();

            return verificacion.Count != 0;

        }
        
        [UseApplicationDbContext]
        public async Task<Dictionary<Tienda,double>> GetTiendasOrderByPrecioPromedioAsync(
             [ScopedService] MyDbContext context,
             TiendaByIdDataLoader dataLoader,
             CancellationToken cancellationToken)
        {

            var group = await context.Ofertas
                 .GroupBy(x => x.tiendaId)
                 .Select(g => new { TiendaId = g.Key, Avg = g.Average(y => y.precio) })
                 .ToListAsync();

            var orderedGroup = group.OrderBy(x => x.Avg);

            var result = new Dictionary<Tienda, double>();
           
            foreach ( var g in orderedGroup)
            {
                var tienda= await dataLoader.LoadAsync(g.TiendaId, cancellationToken);
                result.Add(tienda, (double)g.Avg);
            }
            
            return result;
        }


        [UseApplicationDbContext]
        public async Task<Dictionary<Tienda, int>> GetTiendasOrderByFavAsync(
             [ScopedService] MyDbContext context,
             TiendaByIdDataLoader dataLoader,
             CancellationToken cancellationToken)
        {

            var group = await context.UsuarioTiendaFavs
                 .GroupBy(x => x.tiendaId)
                 .Select(g => new { TiendaId = g.Key, Count = g.Count() })
                 .ToListAsync();

            var orderedGroup = group.OrderByDescending(x => x.Count);

            var result = new Dictionary<Tienda, int>();

            foreach (var g in orderedGroup)
            {
                var tienda = await dataLoader.LoadAsync(g.TiendaId, cancellationToken);
                result.Add(tienda, (int)g.Count);
            }

            return result;
        }



    }
}