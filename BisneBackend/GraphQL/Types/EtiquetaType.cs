using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.DataLoader;


namespace BisneBackend.GraphQL.Types
{
    public class EtiquetaType : ObjectType<Etiqueta>
    {
        protected override void Configure(IObjectTypeDescriptor<Etiqueta> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<EtiquetaByIdDataLoader>()
                .LoadAsync(id, ctx.RequestAborted));

        }

        
    }
}
