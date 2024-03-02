using BisneBackend.Data.Models;
using BisneBackend.GraphQL.Common;
namespace BisneBackend.GraphQL.Categorias
{
    public class CategoriaPayloadBase: Payload
    {
        protected CategoriaPayloadBase(Categoria categoria)
        {
            Categoria = categoria;
        }

        protected CategoriaPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Categoria? Categoria { get; }
    }
}
