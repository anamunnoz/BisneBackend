using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.Common;

namespace BisneBackend.GraphQL.Etiquetas
{
    public class AddEtiquetaPayload : EtiquetaPayloadBase
    {
        public AddEtiquetaPayload(Etiqueta etiqueta) : base(etiqueta) { }
        public AddEtiquetaPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
