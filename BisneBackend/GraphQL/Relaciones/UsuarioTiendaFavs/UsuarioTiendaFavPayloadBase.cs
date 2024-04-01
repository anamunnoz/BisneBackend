using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Relaciones.UsuarioTiendaFavs
{

    public class UsuarioTiendaFavPayloadBase : Payload
    {

        protected UsuarioTiendaFavPayloadBase(UsuarioTiendaFav usuarioTiendaFav)
        {
            UsuarioTiendaFav = usuarioTiendaFav;
        }

        protected UsuarioTiendaFavPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public UsuarioTiendaFav UsuarioTiendaFav { get; }
    }
    
}
