using BisneBackend.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Ofertas
{
    public class AddOfertaPayload: OfertaPayloadBase
    {
        public AddOfertaPayload(UserError error)
            : base(new[] { error }) { }

        public AddOfertaPayload(Oferta oferta) : base(oferta) { }

        public AddOfertaPayload(IReadOnlyList<UserError> errors) : base(errors) { }
    }
}
