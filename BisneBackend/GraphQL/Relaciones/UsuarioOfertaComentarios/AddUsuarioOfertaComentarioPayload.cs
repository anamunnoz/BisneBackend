using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Relaciones.UsuarioOfertaComentarios
{
    public class AddUsuarioOfertaComentarioPayload : UsuarioOfertaComentarioPayloadBase
    {
        public AddUsuarioOfertaComentarioPayload(UsuarioOfertaComentario usuarioOfertaComentario) : base(usuarioOfertaComentario) { }
        public AddUsuarioOfertaComentarioPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
