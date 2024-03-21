using BisneBackend.Data;
using BisneBackend.Data.Extensions;
using BisneBackend.Data.Models;
using BisneBackend.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;


namespace BisneBackend.GraphQL.Types
{
    public class FacturaType : ObjectType<Factura>
    {
        protected override void Configure(IObjectTypeDescriptor<Factura> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<FacturaByIdByDataLoader>()
                .LoadAsync(id, ctx.RequestAborted));
            descriptor
                .Field(t => t.FacturaOfertas)
                .ResolveWith<FacturaResolvers>(t => t.GetOfertasAsync(default!, default!, default!, default))
                .UseDbContext<MyDbContext>()
                .Name("ofertas");

        }

        private class FacturaResolvers
        {
            public async Task<IEnumerable<Oferta>> GetOfertasAsync(
                Factura factura,
                [ScopedService] MyDbContext dbContext,
                OfertaByIdDataLoader ofertaById,
                CancellationToken cancellationToken)
            {
                int[] ofertaIds = await dbContext.Facturas
                    .Where(s => s.Id == factura.Id)
                    .Include(s => s.FacturaOfertas)
                    .SelectMany(s => s.FacturaOfertas.Select(t => t.ofertaId))
                    .ToArrayAsync();

                return await ofertaById.LoadAsync(ofertaIds, cancellationToken);

            }
        }
    }
}
