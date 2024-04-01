using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Relaciones.UsuarioOfertaComentarios
{
    [ExtendObjectType("Mutation")]
    public class UsuarioOfertaComentarioMutations
    {
        [UseApplicationDbContext]
        public async Task<AddUsuarioOfertaComentarioPayload> AddUsuarioOfertaComentarioAsync(
            AddUsuarioOfertaComentarioInput input,
            [ScopedService] MyDbContext context)
        {
            var usuarioOfertaComentario = new UsuarioOfertaComentario
            {
                usuarioId = input.usuarioId,
                ofertaId = input.ofertaId,
                comentario = input.comentario
            };

            context.UsuarioOfertaComentarios.Add(usuarioOfertaComentario);
            await context.SaveChangesAsync();


            return new AddUsuarioOfertaComentarioPayload(usuarioOfertaComentario);
        }

        [UseApplicationDbContext]
        public async Task<AddUsuarioOfertaComentarioPayload> UpdateUsuarioOfertaComentarioAsync(
            AddUsuarioOfertaComentarioInput input,
            [ScopedService] MyDbContext context,
            CancellationToken cancellationToken)
        {
            UsuarioOfertaComentario usuarioOfertaComentario = await context.UsuarioOfertaComentarios.FindAsync(input.usuarioId, input.ofertaId);
            usuarioOfertaComentario.comentario = input.comentario;

            await context.SaveChangesAsync(cancellationToken);

            return new AddUsuarioOfertaComentarioPayload(usuarioOfertaComentario);
        }

    }
}
