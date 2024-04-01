using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Relaciones.UsuarioTiendaFavs
{
    public record AddUsuarioTiendaFavInput(
        [property: ID(nameof(Usuario_Registrado))] int usuarioId,
        [property: ID(nameof(Tienda))] int tiendaId

    );
    
}
