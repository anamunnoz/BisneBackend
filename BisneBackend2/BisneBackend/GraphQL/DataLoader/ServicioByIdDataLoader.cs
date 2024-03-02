using BisneBackend.Data;
using BisneBackend.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BisneBackend.GraphQL.DataLoader
{
    public class ServicioByIdDataLoader : BatchDataLoader<int, Servicio>
    {
        private readonly IDbContextFactory<MyDbContext> _dbContextFactory;

        public ServicioByIdDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<MyDbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }
        protected override async Task<IReadOnlyDictionary<int, Servicio>> LoadBatchAsync(
           IReadOnlyList<int> keys,
           CancellationToken cancellationToken)
        {
            await using MyDbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.Servicios
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }

    }
}
