using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Relaciones.UsuarioOfertaValoraciones
{
    public class UsuarioOfertaValoracionPayloadBase : Payload
    {
        protected UsuarioOfertaValoracionPayloadBase(UsuarioOfertaValoracion usuarioOfertaValoracion)
        {
            UsuarioOfertaValoracion = usuarioOfertaValoracion;
        }

        protected UsuarioOfertaValoracionPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public UsuarioOfertaValoracion UsuarioOfertaValoracion { get; }
    }
}
