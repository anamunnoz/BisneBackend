using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Relaciones.UsuarioOfertaFavs
{
    [ExtendObjectType("Mutation")]
    public class UsuarioOfertaFavMutations
    {
        [UseApplicationDbContext]
        public async Task<AddUsuarioOfertaFavPayload> AddUsuarioOfertaFavAsync(
            AddUsuarioOfertaFavInput input,
            [ScopedService] MyDbContext context)
        {
            var usuarioOfertaFav = new UsuarioOfertaFav
            {
                usuarioId = input.usuarioId,
                ofertaId = input.ofertaId
            };

            context.UsuarioOfertaFavs.Add(usuarioOfertaFav);
            await context.SaveChangesAsync();


            return new AddUsuarioOfertaFavPayload(usuarioOfertaFav);
        }

        [UseApplicationDbContext]
        public async Task<AddUsuarioOfertaFavPayload> DeleteUsuarioOfertaFavAsync(
           [ID(nameof(Oferta))] int ofertaId,
           [ID(nameof(Usuario_Registrado))] int usuarioId,
           [ScopedService] MyDbContext context)
        {
            var favorito = context.UsuarioOfertaFavs
                .Where(t => t.ofertaId == ofertaId)
                .Where(u => u.usuarioId == usuarioId)
                .FirstOrDefault();
            if (favorito == null)
            {
                throw new Exception($"No se encontró el favorito con el id dado");
            }

            context.UsuarioOfertaFavs.Remove(favorito);
            await context.SaveChangesAsync();

            return new AddUsuarioOfertaFavPayload(favorito);
        }
    }


}
