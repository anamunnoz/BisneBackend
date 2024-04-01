using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.DataLoader;


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
        }
        
       
    }
}
