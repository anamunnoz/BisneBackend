using BisneBackend.Data.Models;

namespace BisneBackend.GraphQL.Tiendas
{
    public record AddTiendaInput(
        string nombre,
        string descripcion,
        string? horario,
        int? numeroWhatsapp,
        int? numeroTelefono,
        string? usuarioTelegram,
        string? linkFacebook,
        string? linkInstagram,
        string? linkExtra,
        string? urlImagen,
        [ID(nameof(AdministradordeTienda))]
        int administradorId);
}
