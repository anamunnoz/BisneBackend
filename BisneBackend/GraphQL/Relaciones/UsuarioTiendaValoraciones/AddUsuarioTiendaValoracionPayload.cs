using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Relaciones.UsuarioTiendaValoraciones
{
    public class AddUsuarioTiendaValoracionPayload : UsuarioTiendaValoracionPayloadBase
    {
        public AddUsuarioTiendaValoracionPayload(UsuarioTiendaValoracion usuarioTiendaValoracion) : base(usuarioTiendaValoracion) { }
        public AddUsuarioTiendaValoracionPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
