using BisneBackend.Data.Models;

namespace BisneBackend.GraphQL.Ofertas
{
    public record AddOfertaInput(
        string nombre,
        string descripcion,
        int precio,
        string imageURL,
        [property: ID(nameof(Tienda))]
        int tiendaId
        );
    
}
