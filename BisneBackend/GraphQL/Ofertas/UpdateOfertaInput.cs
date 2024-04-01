using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Ofertas
{
    public record UpdateOfertaInput(
        [property: ID(nameof(Oferta))] int Id,
        string? descripcion,
        string? nombre,
        int? precio,
        string? imageURL,
        [property: ID(nameof(Categoria))]
        int? categoriaId,
        [property: ID(nameof(Etiqueta))]
        int? etiquetaId
        );
}
