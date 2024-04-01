using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Relaciones.UsuarioTiendaComentarios
{
    public class UsuarioTiendaComentarioPayloadBase: Payload
    {
        protected UsuarioTiendaComentarioPayloadBase(UsuarioTiendaComentario usuarioTiendaComentario)
        {
            UsuarioTiendaComentario = usuarioTiendaComentario;
        }

        protected UsuarioTiendaComentarioPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public UsuarioTiendaComentario UsuarioTiendaComentario { get; }
    }
}
