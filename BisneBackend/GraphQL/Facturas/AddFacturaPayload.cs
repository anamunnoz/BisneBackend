using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Facturas
{
    public class AddFacturaPayload: FacturaPayloadBase
    {
        public AddFacturaPayload(UserError error)
            : base(new[] { error }) { }

        public AddFacturaPayload(Factura factura) : base(factura) { }

        public AddFacturaPayload(IReadOnlyList<UserError> errors) : base(errors) { }
    }
}
