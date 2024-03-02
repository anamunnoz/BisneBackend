using BisneBackend.Data;
using BisneBackend.Data.Extensions;
using BisneBackend.Data.Models;
using BisneBackend.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace BisneBackend.GraphQl
{
    [ExtendObjectType("Query")]
    public class CategoriaQueries
    {  
        //get all
        [UseApplicationDbContext]
        public Task<List<Categoria>> GetCategorias([ScopedService] MyDbContext context) =>
            context.Categorias.ToListAsync();

        /*
        [UseApplicationDbContext]
        public Task<List<Oferta>> GetOfertas([ScopedService] MyDbContext context) =>
            context.Ofertas.ToListAsync();
*/


        //get by id

        public Task<Categoria> GetCategoriaAsync(
             /*[ID(nameof(Categoria))]*/ int id,
             CategoriaByIdDataLoader dataLoader,
             CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);
    }
}
