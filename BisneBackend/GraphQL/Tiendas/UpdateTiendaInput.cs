using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Tiendas
{
    public record UpdateTiendaInput(
        [property: ID(nameof(Tienda))]int Id, 
        string? descripcion,
        string? horario,
        string? numeroWhatsapp,
        string? numeroTelefono,
        string? direccion,
        string? usuarioTelegram,
        string? linkFacebook,
        string? linkInstagram,
        string? linkExtra,
        string? urlImagen);
}
