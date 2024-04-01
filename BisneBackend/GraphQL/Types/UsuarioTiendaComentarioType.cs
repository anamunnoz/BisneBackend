using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Types
{
    public class UsuarioTiendaComentarioType : ObjectType<UsuarioTiendaComentario>
    {
        protected override void Configure(IObjectTypeDescriptor<UsuarioTiendaComentario> descriptor)
        {

            descriptor
                .Field(t => t.usuarioId)
                .ID("Usuario_Registrado");
            descriptor
                .Field(t => t.tiendaId)
                .ID("Tienda");
        }
    }
}
