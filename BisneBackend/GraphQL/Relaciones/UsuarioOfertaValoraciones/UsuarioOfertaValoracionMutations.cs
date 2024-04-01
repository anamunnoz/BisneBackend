using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Relaciones.UsuarioOfertaValoraciones
{
    [ExtendObjectType("Mutation")]
    public class UsuarioOfertaValoracionMutations
    {
        [UseApplicationDbContext]
        public async Task<AddUsuarioOfertaValoracionPayload> AddUsuarioOfertaValoracionAsync(
            AddUsuarioOfertaValoracionInput input,
            [ScopedService] MyDbContext context)
        {
            var usuarioOfertaValoracion = new UsuarioOfertaValoracion
            {
                usuarioId = input.usuarioId,
                ofertaId = input.ofertaId,
                valoracion = input.valoracion
            };

            context.UsuarioOfertaValoraciones.Add(usuarioOfertaValoracion);
            await context.SaveChangesAsync();


            return new AddUsuarioOfertaValoracionPayload(usuarioOfertaValoracion);
        }

        [UseApplicationDbContext]
        public async Task<AddUsuarioOfertaValoracionPayload> UpdateUsuarioOfertaValoracionAsync(
            AddUsuarioOfertaValoracionInput input,
            [ScopedService] MyDbContext context,
            CancellationToken cancellationToken)
        {
            UsuarioOfertaValoracion usuarioOfertaValoracion = await context.UsuarioOfertaValoraciones.FindAsync(input.usuarioId, input.ofertaId);
            usuarioOfertaValoracion.valoracion = input.valoracion;

            await context.SaveChangesAsync(cancellationToken);

            return new AddUsuarioOfertaValoracionPayload(usuarioOfertaValoracion);
        }

    }
}
