using BisneBackend.Data.Models;

namespace BisneBackend.GraphQL.Facturas
{
    public record AddFacturaInput(
        [property: ID(nameof(Usuario_Registrado))]
        int usuarioid,
        DateOnly fecha,
        string? direccion_envio);
}
