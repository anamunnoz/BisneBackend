using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Relaciones.UsuarioTiendaComentarios
{
    public class AddUsuarioTiendaComentarioPayload: UsuarioTiendaComentarioPayloadBase
    {
        public AddUsuarioTiendaComentarioPayload(UsuarioTiendaComentario usuarioTiendaComentario) : base(usuarioTiendaComentario) { }
        public AddUsuarioTiendaComentarioPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
