using BisneBackend.Data.Models;

namespace BisneBackend.GraphQL.Tiendas
{
    public record UpdateTiendaInput


    ([ID(nameof(Tienda))] int Id, 
        string? descripcion,
        string? horario,
        int? numeroWhatsapp,
        int? numeroTelefono,
        string? usuarioTelegram,
        string? linkFacebook,
        string? linkInstagram,
        string? linkExtra,
        string? urlImagen);
}
