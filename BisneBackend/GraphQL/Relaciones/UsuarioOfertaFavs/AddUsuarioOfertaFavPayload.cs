using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Relaciones.UsuarioOfertaFavs
{
    public class AddUsuarioOfertaFavPayload : UsuarioOfertaFavPayloadBase
    {
        public AddUsuarioOfertaFavPayload(UsuarioOfertaFav usuarioOfertaFav) : base(usuarioOfertaFav) { }
        public AddUsuarioOfertaFavPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

    }
}
