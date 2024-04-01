using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Relaciones.UsuarioTiendaValoraciones
{
    [ExtendObjectType("Mutation")]
    public class UsuarioTiendaValoracionMutations
    {
        [UseApplicationDbContext]
        public async Task<AddUsuarioTiendaValoracionPayload> AddUsuarioTiendaValoracionAsync(
            AddUsuarioTiendaValoracionInput input,
            [ScopedService] MyDbContext context)
        {
            var usuarioTiendaValoracion = new UsuarioTiendaValoracion
            {
                usuarioId = input.usuarioId,
                tiendaId = input.tiendaId,
                valoracion=input.valoracion
            };

            context.UsuarioTiendaValoraciones.Add(usuarioTiendaValoracion);
            await context.SaveChangesAsync();


            return new AddUsuarioTiendaValoracionPayload(usuarioTiendaValoracion);
        }

        [UseApplicationDbContext]
        public async Task<AddUsuarioTiendaValoracionPayload> UpdateUsuarioTiendaValoracionAsync(
            AddUsuarioTiendaValoracionInput input,
            [ScopedService] MyDbContext context,
            CancellationToken cancellationToken)
        {
            UsuarioTiendaValoracion usuarioTiendaValoracion = await context.UsuarioTiendaValoraciones.FindAsync(input.usuarioId,input.tiendaId);
            usuarioTiendaValoracion.valoracion = input.valoracion;

            await context.SaveChangesAsync(cancellationToken);

            return new AddUsuarioTiendaValoracionPayload(usuarioTiendaValoracion);
        }

    }
}
