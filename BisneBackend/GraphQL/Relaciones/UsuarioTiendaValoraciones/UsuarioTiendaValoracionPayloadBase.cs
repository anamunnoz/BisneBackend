using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Relaciones.UsuarioTiendaValoraciones
{
    public class UsuarioTiendaValoracionPayloadBase : Payload
    {
        protected UsuarioTiendaValoracionPayloadBase(UsuarioTiendaValoracion usuarioTiendaValoracion)
        {
            UsuarioTiendaValoracion = usuarioTiendaValoracion;
        }

        protected UsuarioTiendaValoracionPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public UsuarioTiendaValoracion UsuarioTiendaValoracion { get; }
    }
}
