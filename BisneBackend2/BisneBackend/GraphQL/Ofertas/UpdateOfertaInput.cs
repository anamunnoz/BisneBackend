using BisneBackend.Data.Models;

namespace BisneBackend.GraphQL.Ofertas
{
    public record UpdateOfertaInput(
        [property: ID(nameof(Oferta))] int Id,
        string? descripcion,
        string? nombre,
        int? precio,
        string? imageURL
        );
}
