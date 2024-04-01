using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace BisneBackend.GraphQL.Facturas
{
    [ExtendObjectType("Query")]
    public class FacturaQueries
    {

        [UseApplicationDbContext]
        public async Task<Dictionary<Oferta,double[]>> GetFacturaOfertasAsync(
            [ID(nameof(Factura))] int id,
            [ScopedService] MyDbContext context,
            OfertaByIdDataLoader dataLoader,
            CancellationToken cancellationToken)
        {
            Dictionary<Oferta, double[]> vs = new Dictionary<Oferta, double[]>();
            var facturaofertas= await context.FacturaOfertas
                .Where(u => u.facturaId == id).ToArrayAsync();
            foreach( var x in facturaofertas)
            {
                var oferta = await dataLoader.LoadAsync(x.ofertaId, cancellationToken);
                vs.Add(oferta,new double[] {x.cantidad,x.monto_total});
            }
            return vs;
        }

        [UseApplicationDbContext]
        public async Task<int[]> GetFacturasInfo([ScopedService] MyDbContext context)
        {
            int[] result= new int[2];
            result[0] = context.Facturas.Count();
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            result[1] = context.Facturas.Where(f=>f.fecha==today).Count();
            return result;
        }

    }
}
