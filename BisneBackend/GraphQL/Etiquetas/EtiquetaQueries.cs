using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;


namespace BisneBackend.GraphQL.Etiquetas
{
    [ExtendObjectType("Query")]
    public class EtiquetaQueries
    {
        //get all
        [UseApplicationDbContext]
        public Task<List<Etiqueta>> GetEtiquetas([ScopedService] MyDbContext context) =>
            context.Etiquetas.ToListAsync();


        //get by id

        public Task<Etiqueta> GetEtiquetaAsync(
             [ID(nameof(Etiqueta))] int id,
             EtiquetaByIdDataLoader dataLoader,
             CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);



    }
}
