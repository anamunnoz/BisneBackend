using BisneBackend.Data.Models;

namespace BisneBackend.GraphQL.Tiendas
{
    public record AddTiendaInput(
        string nombre,
        string descripcion,
        string? direccion,
        string? horario,
        string? numeroWhatsapp,
        string? numeroTelefono,
        string provincia,
        string municipio,
        string? usuarioTelegram,
        string? linkFacebook,
        string? linkInstagram,
        string? linkExtra,
        string? urlImagen,
        [property: ID(nameof(Usuario_Registrado))]
        int administradorId);
}
