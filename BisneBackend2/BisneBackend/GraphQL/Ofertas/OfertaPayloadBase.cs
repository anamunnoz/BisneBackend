using BisneBackend.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Ofertas
{
    public class OfertaPayloadBase: Payload
    {
        protected OfertaPayloadBase(Oferta oferta)
        {
            Oferta = oferta;
        }

        protected OfertaPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Oferta? Oferta { get; }

    }
}
