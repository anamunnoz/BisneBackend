using BisneBackend.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Facturas
{
    public class FacturaPayloadBase: Payload
    {
        protected FacturaPayloadBase(Factura factura)
        {
            Factura = factura;
        }

        protected FacturaPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Factura? Factura { get; }
    }
}
