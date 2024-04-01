using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Relaciones.UsuarioOfertaFavs
{
    public record AddUsuarioOfertaFavInput(
        [property: ID(nameof(Usuario_Registrado))] int usuarioId,
        [property: ID(nameof(Oferta))] int ofertaId

    );

}
