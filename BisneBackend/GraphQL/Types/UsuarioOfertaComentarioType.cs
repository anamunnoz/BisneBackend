using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Types
{
    public class UsuarioOfertaComentarioType : ObjectType<UsuarioOfertaComentario>
    {
        protected override void Configure(IObjectTypeDescriptor<UsuarioOfertaComentario> descriptor)
        {
            descriptor
                .Field(t => t.usuarioId)
                .ID("Usuario_Registrado");
            descriptor
                .Field(t => t.ofertaId)
                .ID("Oferta");
        }
    }
}
