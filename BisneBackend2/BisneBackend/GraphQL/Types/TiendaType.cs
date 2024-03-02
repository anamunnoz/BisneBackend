using BisneBackend.Data;
using BisneBackend.Data.Extensions;
using BisneBackend.Data.Models;
using BisneBackend.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;


namespace BisneBackend.GraphQL.Types
{
    public class TiendaType : ObjectType<Tienda>
    {
        protected override void Configure(IObjectTypeDescriptor<Tienda> descriptor)
        {
            /*descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<TiendaByIdDataLoader>()
                .LoadAsync(id, ctx.RequestAborted));*/
            descriptor
                .Field(t => t.ofertas)
                .ResolveWith<TiendaResolvers>(t => t.GetOfertasAsync(default!, default!, default!, default))
                .UseDbContext<MyDbContext>()
                .Name("ofertas");
            descriptor
                .Field(t => t.usuarioTiendaFavs)
                .ResolveWith<TiendaResolvers>(t => t.GetUsuariosFavAsync(default!, default!, default!, default))
                .UseDbContext<MyDbContext>()
                .Name("UsuariosFav");

        }

        private class TiendaResolvers
        {
            public async Task<IEnumerable<Oferta>> GetOfertasAsync(
                Tienda tienda,
                [ScopedService] MyDbContext dbContext,
                OfertaByIdDataLoader ofertaById,
                CancellationToken cancellationToken)
            {
             
                int[] ofertaIds= await dbContext.Tiendas
                    .Where(s => s.Id==tienda.Id)
                    .SelectMany(s=> s.ofertas.Select(a=>a.Id))
                    .ToArrayAsync();

                return await ofertaById.LoadAsync(ofertaIds, cancellationToken);

            }

            public async Task<IEnumerable<Usuario_Registrado>> GetUsuariosFavAsync(
                Tienda tienda,
                [ScopedService] MyDbContext dbContext,
                UsuarioByIdDataLoader usuarioById,
                CancellationToken cancellationToken)
            {
                int[] usuarioIds = await dbContext.Tiendas
                    .Where(s => s.Id == tienda.Id)
                    .Include(s => s.usuarioTiendaFavs)
                    .SelectMany(s => s.usuarioTiendaFavs.Select(t => t.usuarioId))
                    .ToArrayAsync();

                return await usuarioById.LoadAsync(usuarioIds, cancellationToken);

            }
        }
    }
}
