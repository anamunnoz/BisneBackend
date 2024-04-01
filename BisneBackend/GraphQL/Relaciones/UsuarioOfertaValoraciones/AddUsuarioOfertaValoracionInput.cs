using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Relaciones.UsuarioOfertaValoraciones
{
    public record AddUsuarioOfertaValoracionInput(
        [property: ID(nameof(Usuario_Registrado))] int usuarioId,
        [property: ID(nameof(Oferta))] int ofertaId,
        int valoracion
    );
}
