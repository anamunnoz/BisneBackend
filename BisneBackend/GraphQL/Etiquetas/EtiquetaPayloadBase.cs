using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;
namespace BisneBackend.GraphQL.Etiquetas
{
    public class EtiquetaPayloadBase : Payload
    {
        protected EtiquetaPayloadBase(Etiqueta etiqueta)
        {
            Etiqueta = etiqueta;
        }

        protected EtiquetaPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public Etiqueta? Etiqueta { get; }
    }
}
