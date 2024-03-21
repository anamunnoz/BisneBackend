using BisneBackend.Data;
using BisneBackend.Data.Extensions;
using BisneBackend.Data.Models;
using BisneBackend.GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace BisneBackend.GraphQL.Usuarios
{
    [ExtendObjectType("Query")]
    public class UsuarioQueries
    {
        [UseApplicationDbContext]
        public Task<List<Usuario_Registrado>> GetUsuarios([ScopedService] MyDbContext context) =>
           context.Usuarios_Registrados.ToListAsync();

        public Task<Usuario_Registrado> GetUsuarioAsync(
             [ID(nameof(Usuario_Registrado))] int id,
             UsuarioByIdDataLoader dataLoader,
             CancellationToken cancellationToken) => dataLoader.LoadAsync(id, cancellationToken);
    }
}
