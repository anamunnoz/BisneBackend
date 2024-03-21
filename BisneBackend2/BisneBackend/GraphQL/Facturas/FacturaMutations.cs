using BisneBackend.Data;
using BisneBackend.Data.Extensions;
using BisneBackend.Data.Models;

namespace BisneBackend.GraphQL.Facturas
{
    [ExtendObjectType("Mutation")]
    public class FacturaMutations
    {
        [UseApplicationDbContext]
        public async Task<AddFacturaPayload> AddFacturaAsync(
          AddFacturaInput input,
          [ScopedService] MyDbContext context,
          CancellationToken cancellationToken)
        {
            var factura = new Factura
            {
                usuarioId = input.usuarioid,
                fecha = input.fecha,
                direccion_envio = input.direccion_envio
            };

            context.Facturas.Add(factura);
            await context.SaveChangesAsync(cancellationToken);

            return new AddFacturaPayload(factura);
        }


    }
}
