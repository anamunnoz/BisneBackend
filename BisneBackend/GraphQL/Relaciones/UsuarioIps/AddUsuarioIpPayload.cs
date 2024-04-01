using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Relaciones.UsuarioIps
{
    public class AddUsuarioIpPayload : UsuarioIpPayloadBase
    {
        public AddUsuarioIpPayload(UsuarioIp usuarioIp) : base(usuarioIp) { }
        public AddUsuarioIpPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
