using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Relaciones.FacturaOfertas
{
    public class AddFacturaOfertaPayload: FacturaOfertaPayloadBase
    {
        public AddFacturaOfertaPayload(FacturaOferta facturaOferta) : base(facturaOferta) { }
        public AddFacturaOfertaPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
