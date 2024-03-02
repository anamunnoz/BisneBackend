using BisneBackend.Data;
using BisneBackend.Data.Models;
using Microsoft.EntityFrameworkCore;



namespace BisneBackend.GraphQL.DataLoader
{
    public class OfertaByIdDataLoader: BatchDataLoader<int, Oferta>
    {
        private readonly IDbContextFactory<MyDbContext> _dbContextFactory;

        public OfertaByIdDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<MyDbContext> dbContextFactory)
            : base(batchScheduler){
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }
        protected override async Task<IReadOnlyDictionary<int, Oferta>> LoadBatchAsync(
           IReadOnlyList<int> keys,
           CancellationToken cancellationToken){
            await using MyDbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.Ofertas
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
