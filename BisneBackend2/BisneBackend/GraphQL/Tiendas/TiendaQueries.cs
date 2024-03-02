using BisneBackend.Data;
using BisneBackend.Data.Extensions;
using BisneBackend.Data.Models;
using BisneBackend.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace BisneBackend.GraphQl
{
    [ExtendObjectType("Query")]
    public class TiendaQueries
    {
        //get all
        [UseApplicationDbContext]
        public Task<List<Tienda>> GetTiendas([ScopedService] MyDbContext context) =>
            context.Tiendas.ToListAsync();

        /*
        [UseApplicationDbContext]
        public Task<List<Oferta>> GetOfertas([ScopedService] MyDbContext context) =>
            context.Ofertas.ToListAsync();
*/


        //get by id

        public Task<Tienda> GetTiendaAsync(
             /*[ID(nameof(Categoria))]*/ int id,
             TiendaByIdDataLoader dataLoader,
             CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);
    }
}