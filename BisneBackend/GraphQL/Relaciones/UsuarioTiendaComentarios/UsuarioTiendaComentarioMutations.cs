using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Relaciones.UsuarioTiendaComentarios
{
    [ExtendObjectType("Mutation")]
    public class UsuarioTiendaComentarioMutations
    {
        [UseApplicationDbContext]
        public async Task<AddUsuarioTiendaComentarioPayload> AddUsuarioTiendaComentarioAsync(
            AddUsuarioTiendaComentarioInput input,
            [ScopedService] MyDbContext context)
        {
            var usuarioTiendaComentario = new UsuarioTiendaComentario
            {
                usuarioId = input.usuarioId,
                tiendaId = input.tiendaId,
                comentario=input.comentario
            };

            context.UsuarioTiendaComentarios.Add(usuarioTiendaComentario);
            await context.SaveChangesAsync();


            return new AddUsuarioTiendaComentarioPayload(usuarioTiendaComentario);
        }

        [UseApplicationDbContext]
        public async Task<AddUsuarioTiendaComentarioPayload> UpdateUsuarioTiendaComentarioAsync(
            AddUsuarioTiendaComentarioInput input,
            [ScopedService] MyDbContext context,
            CancellationToken cancellationToken)
        {
            UsuarioTiendaComentario usuarioTiendaComentario = await context.UsuarioTiendaComentarios.FindAsync(input.usuarioId,input.tiendaId);
            usuarioTiendaComentario.comentario = input.comentario;

            await context.SaveChangesAsync(cancellationToken);

            return new AddUsuarioTiendaComentarioPayload(usuarioTiendaComentario);
        }

    }
}
