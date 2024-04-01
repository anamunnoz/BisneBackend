using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.DataLoader;

namespace BisneBackend.GraphQL.Types
{
    public class TiendaType : ObjectType<Tienda>
    {
        protected override void Configure(IObjectTypeDescriptor<Tienda> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<TiendaByIdDataLoader>()
                .LoadAsync(id, ctx.RequestAborted));
           
        }

        
    }
}
