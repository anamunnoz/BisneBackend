using BisneBackend.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Tiendas
{
    public class TiendaPayloadBase: Payload
    {
        protected TiendaPayloadBase(Tienda tienda)
        {
            Tienda = tienda;
        }

        protected TiendaPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Tienda? Tienda { get; }
    }
}
