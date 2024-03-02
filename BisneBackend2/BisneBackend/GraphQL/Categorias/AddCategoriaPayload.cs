using BisneBackend.Data.Models;
using BisneBackend.GraphQL.Categorias;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Payloads
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
