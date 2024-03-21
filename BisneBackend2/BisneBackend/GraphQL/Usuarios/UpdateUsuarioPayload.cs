using BisneBackend.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Usuarios
{
    public class UpdateUsuarioPayload: UsuarioPayloadBase
    {
        public UpdateUsuarioPayload(Usuario_Registrado usuario)
            : base(usuario) { }

        public UpdateUsuarioPayload(IReadOnlyList<UserError> errors)
            : base(errors) { }
        
    }
}
