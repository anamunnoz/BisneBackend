using BisneBackend.Data;
using BisneBackend.Data.Extensions;
using BisneBackend.Data.Models;
using BisneBackend.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace BisneBackend.GraphQL.Ofertas
{
    [ExtendObjectType("Query")]
    public class OfertaQueries
    {
        [UseApplicationDbContext]
        public Task<List<Oferta>> GetOfertas([ScopedService] MyDbContext context) =>
            context.Ofertas.ToListAsync();

        public Task<Oferta> GetOfertaAsync(
             [ID(nameof(Oferta))] int id,
             OfertaByIdDataLoader dataLoader,
             CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);
    }
}
