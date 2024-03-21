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
        //PINCHA
        //skip y take para paginar
        
        [UseApplicationDbContext]
        public Task<List<Tienda>> GetTiendas([ScopedService] MyDbContext context) =>
            context.Tiendas.ToListAsync();
        
        /*
        [UseApplicationDbContext]
        [UsePaging]
        
        public IQueryable<Tienda> GetTiendas(
            [ScopedService] MyDbContext context) => context.Tiendas;*/
        
                



        //get by id

        public Task<Tienda> GetTiendaAsync(
             [ID(nameof(Tienda))] int id,
             TiendaByIdDataLoader dataLoader,
             CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);
    }
}