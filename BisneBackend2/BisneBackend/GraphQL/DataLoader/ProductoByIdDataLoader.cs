using BisneBackend.Data;
using BisneBackend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BisneBackend.GraphQL.DataLoader
{
    public class ProductoByIdDataLoader : BatchDataLoader<int, Producto>
    {
        private readonly IDbContextFactory<MyDbContext> _dbContextFactory;

        public ProductoByIdDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<MyDbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }
        protected override async Task<IReadOnlyDictionary<int, Producto>> LoadBatchAsync(
           IReadOnlyList<int> keys,
           CancellationToken cancellationToken)
        {
            await using MyDbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.Productos
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }

    }
}
