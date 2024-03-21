using BisneBackend.Data;
using BisneBackend.Data.Extensions;
using BisneBackend.Data.Models;
using BisneBackend.GraphQl;
using BisneBackend.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace BisneBackend.GraphQL.Types
{
    public class CategoriaType: ObjectType<Categoria>
    {
        protected override void Configure(IObjectTypeDescriptor<Categoria> descriptor)
        {
             descriptor
                 .ImplementsNode()
                 .IdField(t => t.Id)
                 .ResolveNode((ctx, id) => ctx.DataLoader<CategoriaByIdDataLoader>()
                 .LoadAsync(id, ctx.RequestAborted));


            descriptor
                .Field(t => t.OfertaCategorias)
                .ResolveWith<CategoriaResolvers>(t => t.GetOfertasAsync(default!, default!, default!, default))
                .UseDbContext<MyDbContext>()
                .Name("ofertas")
                .Type<ListType<OfertaType>>();

            descriptor
                .Field(t => t.padre)
                .ResolveWith<CategoriaResolvers>(t => t.GetPadreAsync(default!, default!, default))
                .UseDbContext<MyDbContext>()
                .Name("padre")
                .Type<CategoriaType>();
            

        }
        
        private class CategoriaResolvers
        {
            public async Task<IEnumerable<Oferta>> GetOfertasAsync(
                Categoria categoria,
                [ScopedService] MyDbContext dbContext,
                OfertaByIdDataLoader ofertaById,
                CancellationToken cancellationToken)
            {
                
                int[] ofertaIds = await dbContext.Categorias
                    .Where(s => s.Id == categoria.Id)
                    .Include(s => s.OfertaCategorias)
                    .SelectMany(s => s.OfertaCategorias.Select(t => t.ofertaId))
                    .ToArrayAsync();
                
                return await ofertaById.LoadAsync(ofertaIds, cancellationToken);
              
            }
            public async Task<Categoria> GetPadreAsync(
                Categoria categoria,
                CategoriaByIdDataLoader categoriaById,
                CancellationToken cancellationToken)
            {

               return (Categoria)await categoriaById.LoadAsync(categoria.padreId, cancellationToken);
                
            }

            
        }
    }
}
