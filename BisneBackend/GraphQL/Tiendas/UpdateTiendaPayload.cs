using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Tiendas
{
    public class UpdateTiendaPayload: TiendaPayloadBase
    {
        public UpdateTiendaPayload(Tienda tienda)
            : base(tienda) { }

        public UpdateTiendaPayload(IReadOnlyList<UserError> errors)
            : base(errors) { }
    }
}
