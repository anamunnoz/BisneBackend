using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Usuarios
{
    public class UsuarioPayloadBase: Payload
    {
        protected UsuarioPayloadBase(Usuario_Registrado usuario)
        {
            Usuario = usuario;
        }

        protected UsuarioPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Usuario_Registrado? Usuario { get; }
    }
}
