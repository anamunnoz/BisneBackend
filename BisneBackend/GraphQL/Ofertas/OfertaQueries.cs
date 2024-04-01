using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace BisneBackend.GraphQL.Ofertas
{
    [ExtendObjectType("Query")]
    public class OfertaQueries
    {
        [UseApplicationDbContext]
        public Task<List<Oferta>> GetOfertas([ScopedService] MyDbContext context) =>
            context.Ofertas.ToListAsync();

        public Task<Oferta> GetOfertaAsync(
             [ID(nameof(Oferta))] int id,
             OfertaByIdDataLoader dataLoader,
             CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);

        [UseApplicationDbContext]
        public async Task<List<Oferta>> GetOfertaNombreAsync(
            string nombre,
            [ScopedService] MyDbContext context)
        {

            var ofertas = await context.Ofertas
                .Where(t => t.nombre.ToLower().Contains(nombre.ToLower())).ToListAsync();


            return ofertas;
        }

        [UseApplicationDbContext]
        public async Task<List<string[]>> GetOfertaComentarioAsync(
             [ID(nameof(Oferta))] int id,
             UsuarioByIdDataLoader dataloader,
             [ScopedService] MyDbContext context,
             CancellationToken cancellationToken)
        {

            List<string[]> usuarioComentario = new List<string[]>();
            var comm = await context.UsuarioOfertaComentarios.ToListAsync();
            foreach (var x in comm)
            {
                if (x.ofertaId == id)
                {
                    var usuario = await dataloader.LoadAsync(x.usuarioId, cancellationToken);
                    string[] info = new string[3] { usuario.nombre, usuario.ImageURL = "", x.comentario };
                    usuarioComentario.Add(info);
                }

            }

            return usuarioComentario;
        }

        [UseApplicationDbContext]
        public async Task<double> GetOfertaValoracionAsync(
             [ID(nameof(Oferta))] int id,
             [ScopedService] MyDbContext context)
        {
            var x = await context.UsuarioOfertaValoraciones.Where(t => t.ofertaId == id).ToListAsync();
            if (x.Count == 0) return 0;
            return x.Average(v => v.valoracion);
        }

        [UseApplicationDbContext]
        public async Task<bool> GetVerificarOfertaComentarioAsync(
             [ID(nameof(Usuario_Registrado))] int usuarioId,
             [ID(nameof(Oferta))] int ofertaId,
             [ScopedService] MyDbContext context)
        {
            var verificacion = await context.UsuarioOfertaComentarios
                 .Where(u => u.usuarioId == usuarioId)
                 .Where(t => t.ofertaId == ofertaId)
                 .ToListAsync();

            return verificacion.Count != 0;

        }

        [UseApplicationDbContext]
        public async Task<Dictionary<Oferta, int>> GetOfertasOrderByFavAsync(
            [ScopedService] MyDbContext context,
            OfertaByIdDataLoader dataLoader,
            CancellationToken cancellationToken)
        {

            var group = await context.UsuarioOfertaFavs
                 .GroupBy(x => x.ofertaId)
                 .Select(g => new { OfertaId = g.Key, Count = g.Count() })
                 .ToListAsync();

            var orderedGroup = group.OrderByDescending(x => x.Count);

            var result = new Dictionary<Oferta, int>();

            foreach (var g in orderedGroup)
            {
                var oferta = await dataLoader.LoadAsync(g.OfertaId, cancellationToken);
                result.Add(oferta, (int)g.Count);
            }

            return result;
        }

        [UseApplicationDbContext]
        public async Task<IReadOnlyList<Oferta>> GetOfertasOrderByPrecio(
             [ScopedService] MyDbContext context)
        {
            return await context.Ofertas.OrderBy(x => x.precio).ToListAsync();
        }
    }
}
