using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.DataLoader;



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
                .Field(t => t.usuarioId)
                .ID("Usuario_Registrado");

        }

        
    }
}
