using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Relaciones.UsuarioTiendaFavs
{
    [ExtendObjectType("Mutation")]
    public class UsuarioTiendaFavMutations
    {
        [UseApplicationDbContext]
        public async Task<AddUsuarioTiendaFavPayload> AddUsuarioTiendaFavAsync(
            AddUsuarioTiendaFavInput input,
            [ScopedService] MyDbContext context)
        {
            var usuarioTiendaFav = new UsuarioTiendaFav
            {
                usuarioId=input.usuarioId,
                tiendaId=input.tiendaId
            };

            context.UsuarioTiendaFavs.Add(usuarioTiendaFav);
            await context.SaveChangesAsync();


            return new AddUsuarioTiendaFavPayload(usuarioTiendaFav);
        }

        [UseApplicationDbContext]
        public async Task<AddUsuarioTiendaFavPayload> DeleteUsuarioTiendaFavAsync(
            [ID(nameof(Tienda))] int tiendaId,
            [ID(nameof(Usuario_Registrado))] int usuarioId,
            [ScopedService] MyDbContext context)
        {
            var favorito = context.UsuarioTiendaFavs
                .Where(t => t.tiendaId == tiendaId)
                .Where(u => u.usuarioId == usuarioId)
                .FirstOrDefault();
            if (favorito == null)
            {
                throw new Exception($"No se encontró el favorito con el id dado");
            }

            context.UsuarioTiendaFavs.Remove(favorito);
            await context.SaveChangesAsync();

            return new AddUsuarioTiendaFavPayload(favorito);
        }
    }

}
