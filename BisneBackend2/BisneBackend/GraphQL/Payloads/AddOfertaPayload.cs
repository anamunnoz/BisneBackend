using BisneBackend.Data.Models;

namespace BisneBackend.GraphQL.Payloads
{
    public class AddOfertaPayload
    {
        public AddOfertaPayload(Oferta ofe)
        {
            oferta = ofe;
        }
        public Oferta oferta { get; }
    }
}
