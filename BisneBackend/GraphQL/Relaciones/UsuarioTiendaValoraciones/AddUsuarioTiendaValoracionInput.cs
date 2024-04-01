using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Relaciones.UsuarioTiendaValoraciones
{
    public record AddUsuarioTiendaValoracionInput(
        [property: ID(nameof(Usuario_Registrado))] int usuarioId,
        [property: ID(nameof(Tienda))] int tiendaId,
        int valoracion
    );
}
