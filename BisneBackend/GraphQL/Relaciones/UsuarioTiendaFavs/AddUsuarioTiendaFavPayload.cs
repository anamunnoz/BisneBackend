using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Relaciones.UsuarioTiendaFavs
{
    public class AddUsuarioTiendaFavPayload: UsuarioTiendaFavPayloadBase
    {
        public AddUsuarioTiendaFavPayload(UsuarioTiendaFav usuarioTiendaFav) : base(usuarioTiendaFav) { }
        public AddUsuarioTiendaFavPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

    }
}
