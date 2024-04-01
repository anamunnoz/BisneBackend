using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Relaciones.UsuarioOfertaFavs
{
    public class UsuarioOfertaFavPayloadBase : Payload
    {
        protected UsuarioOfertaFavPayloadBase(UsuarioOfertaFav usuarioOfertaFav)
        {
            UsuarioOfertaFav = usuarioOfertaFav;
        }

        protected UsuarioOfertaFavPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public UsuarioOfertaFav UsuarioOfertaFav { get; }
    }

}
