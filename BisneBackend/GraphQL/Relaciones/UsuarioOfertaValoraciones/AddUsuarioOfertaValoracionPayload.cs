using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Relaciones.UsuarioOfertaValoraciones
{
    public class AddUsuarioOfertaValoracionPayload : UsuarioOfertaValoracionPayloadBase
    {
        public AddUsuarioOfertaValoracionPayload(UsuarioOfertaValoracion usuarioOfertaValoracion) : base(usuarioOfertaValoracion) { }
        public AddUsuarioOfertaValoracionPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
