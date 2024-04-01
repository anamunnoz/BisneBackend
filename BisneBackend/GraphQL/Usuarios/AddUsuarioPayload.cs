using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Usuarios
{
    public class AddUsuarioPayload: UsuarioPayloadBase
    {
        public AddUsuarioPayload(UserError error)
            : base(new[] { error }) { }

        public AddUsuarioPayload(Usuario_Registrado usuario) : base(usuario) { }

        public AddUsuarioPayload(IReadOnlyList<UserError> errors) : base(errors) { }
    }
}
