using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Relaciones.FacturaOfertas
{
    [ExtendObjectType("Mutation")]
    public class FacturaOfertaMutations
    {
        [UseApplicationDbContext]
        public async Task<AddFacturaOfertaPayload> AddFacturaOfertaAsync(
            AddFacturaOfertaInput input,
            [ScopedService] MyDbContext context)
        {
            var facturaOferta = new FacturaOferta
            {
                ofertaId = input.ofertaId,
                facturaId = input.facturaId,
                monto_total = input.montototal,
                cantidad = input.cantidad
            };
            
            context.FacturaOfertas.Add(facturaOferta);
            await context.SaveChangesAsync();


            return new AddFacturaOfertaPayload(facturaOferta);
        }
    }
}
