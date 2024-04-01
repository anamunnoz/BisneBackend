using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Ofertas
{
    public class UpdateOfertaPayload: OfertaPayloadBase
    {
        public UpdateOfertaPayload(Oferta oferta)
            : base(oferta) { }

        public UpdateOfertaPayload(IReadOnlyList<UserError> errors)
            : base(errors) { }
    }
}
