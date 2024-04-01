using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Ofertas
{
    public record AddOfertaInput(
        string nombre,
        string descripcion,
        int precio,
        string imageURL,
        [property: ID(nameof(Tienda))]
        int tiendaId,
        [property: ID(nameof(Categoria))]
        int categoriaId,
        [property: ID(nameof(Etiqueta))]
        int etiquetaId
        );
    
}
