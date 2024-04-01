using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Relaciones.UsuarioIps
{
    public class UsuarioIpPayloadBase : Payload
    {

        protected UsuarioIpPayloadBase(UsuarioIp usuarioIp)
        {
            UsuarioIp = usuarioIp;
        }

        protected UsuarioIpPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public UsuarioIp UsuarioIp { get; }
    }
}
