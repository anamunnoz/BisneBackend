using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.DataLoader;


namespace BisneBackend.GraphQL.Types
{
    public class UsuarioType : ObjectType<Usuario_Registrado>
    {
        protected override void Configure(IObjectTypeDescriptor<Usuario_Registrado> descriptor)
        {
            descriptor
                .ImplementsNode()
                .IdField(t => t.Id)
                .ResolveNode((ctx, id) => ctx.DataLoader<UsuarioByIdDataLoader>()
                .LoadAsync(id, ctx.RequestAborted));

            descriptor
                .Field(t => t.ImageURL)
                .Type<StringType>();

        }
    }
}