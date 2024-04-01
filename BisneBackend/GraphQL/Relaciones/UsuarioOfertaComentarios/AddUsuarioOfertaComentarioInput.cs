using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Relaciones.UsuarioOfertaComentarios
{
    public record AddUsuarioOfertaComentarioInput(
        [property: ID(nameof(Usuario_Registrado))] int usuarioId,
        [property: ID(nameof(Oferta))] int ofertaId,
        string comentario
    );
}
