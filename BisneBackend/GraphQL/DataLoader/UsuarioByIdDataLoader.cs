using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BisneBackend.GraphQL.DataLoader
{
    public class UsuarioByIdDataLoader : BatchDataLoader<int, Usuario_Registrado>
    {
        private readonly IDbContextFactory<MyDbContext> _dbContextFactory;

        public UsuarioByIdDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<MyDbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }
        protected override async Task<IReadOnlyDictionary<int, Usuario_Registrado>> LoadBatchAsync(
           IReadOnlyList<int> keys,
           CancellationToken cancellationToken)
        {
            await using MyDbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.Usuarios_Registrados
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }

    }
}
