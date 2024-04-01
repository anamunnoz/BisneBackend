using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Tiendas
{
    public class AddTiendaPayload : TiendaPayloadBase
    {
        public AddTiendaPayload(UserError error)
            : base(new[] { error }) {}

        public AddTiendaPayload(Tienda tienda) : base(tienda) {}

        public AddTiendaPayload(IReadOnlyList<UserError> errors) : base(errors) {}

    }
}
