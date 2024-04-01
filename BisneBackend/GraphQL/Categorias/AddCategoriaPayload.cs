using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Categorias
{
    public class AddCategoriaPayload: CategoriaPayloadBase
    {
        public AddCategoriaPayload(Categoria cat): base(cat) { }
        public AddCategoriaPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
