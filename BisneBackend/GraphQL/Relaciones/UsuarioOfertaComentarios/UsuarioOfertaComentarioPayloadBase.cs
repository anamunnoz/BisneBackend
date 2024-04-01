using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Relaciones.UsuarioOfertaComentarios
{
    public class UsuarioOfertaComentarioPayloadBase : Payload
    {
        protected UsuarioOfertaComentarioPayloadBase(UsuarioOfertaComentario usuarioOfertaComentario)
        {
            UsuarioOfertaComentario = usuarioOfertaComentario;
        }

        protected UsuarioOfertaComentarioPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
        public UsuarioOfertaComentario UsuarioOfertaComentario { get; }
    }
}
