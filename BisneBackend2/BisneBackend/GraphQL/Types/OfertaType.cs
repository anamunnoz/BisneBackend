using BisneBackend.Data;
using BisneBackend.Data.Extensions;
using BisneBackend.Data.Models;
using BisneBackend.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;


namespace BisneBackend.GraphQL.Types
{
    public class OfertaType : ObjectType<Oferta>
    {
        protected override void Configure(IObjectTypeDescriptor<Oferta> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<OfertaByIdDataLoader>()
                .LoadAsync(id, ctx.RequestAborted));
            descriptor
                .Field(t => t.OfertaCategorias)
                .ResolveWith<OfertaResolvers>(t => t.GetCategoriasAsync(default!, default!, default!, default))
                .UseDbContext<MyDbContext>()
                .Name("categorias");
            descriptor
                .Field(t => t.FacturaOfertas)
                .ResolveWith<OfertaResolvers>(t => t.GetFacturasAsync(default!, default!, default!, default))
                .UseDbContext<MyDbContext>()
                .Name("facturas");
        }

        private class OfertaResolvers
        {
            public async Task<IEnumerable<Categoria>> GetCategoriasAsync(
                Oferta oferta,
                [ScopedService] MyDbContext dbContext,
                CategoriaByIdDataLoader categoriaById,
                CancellationToken cancellationToken)
            {
                int[] categoriaIds = await dbContext.Ofertas
                    .Where(s => s.Id == oferta.Id)
                    .Include(s => s.OfertaCategorias)
                    .SelectMany(s => s.OfertaCategorias.Select(t => t.categoriaId))
                    .ToArrayAsync();

                return await categoriaById.LoadAsync(categoriaIds, cancellationToken);

            }

            public async Task<IEnumerable<Factura>> GetFacturasAsync(
                Oferta oferta,
                [ScopedService] MyDbContext dbContext,
                FacturaByIdByDataLoader facturaById,
                CancellationToken cancellationToken)
            {
                int[] facturaIds = await dbContext.Facturas
                    .Where(s => s.Id == oferta.Id)
                    .Include(s => s.FacturaOfertas)
                    .SelectMany(s => s.FacturaOfertas.Select(t => t.facturaId))
                    .ToArrayAsync();

                return await facturaById.LoadAsync(facturaIds, cancellationToken);

            }
        }
    }
}
