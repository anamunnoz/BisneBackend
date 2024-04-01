using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BisneBackend.GraphQL.DataLoader
{
    public class CategoriaByIdDataLoader : BatchDataLoader<int, Categoria>
    {
        private readonly IDbContextFactory<MyDbContext> _dbContextFactory;

        public CategoriaByIdDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<MyDbContext> dbContextFactory)
            : base(batchScheduler){
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }
        protected override async Task<IReadOnlyDictionary<int, Categoria>> LoadBatchAsync(
           IReadOnlyList<int> keys,
           CancellationToken cancellationToken){
            await using MyDbContext dbContext =
                _dbContextFactory.CreateDbContext();
            
            return await dbContext.Categorias
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }

    }
}
