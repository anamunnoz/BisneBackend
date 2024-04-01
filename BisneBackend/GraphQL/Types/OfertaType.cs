using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.DataLoader;



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
                .Field(t => t.categoriaId)
                .ID("Categoria");
            descriptor
                .Field(t => t.etiquetaId)
                .ID("Etiqueta");
            descriptor
                .Field(t => t.tiendaId)
                .ID("Tienda");
            
        }

       
    }
}
