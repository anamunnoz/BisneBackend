using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;


namespace BisneBackend.GraphQL.Relaciones.FacturaOfertas
{
    public class FacturaOfertaPayloadBase: Payload
    {

        protected FacturaOfertaPayloadBase(FacturaOferta facturaOferta)
        {
            FacturaOferta = facturaOferta;
        }

        protected FacturaOfertaPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
        
        public FacturaOferta FacturaOferta { get; }
    }
}
