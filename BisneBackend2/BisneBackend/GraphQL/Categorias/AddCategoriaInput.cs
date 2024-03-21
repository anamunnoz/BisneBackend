using BisneBackend.Data.Models;

namespace BisneBackend.GraphQL.Categorias
{
    public record AddCategoriaInput(string nombre, [property: ID(nameof(Categoria))]  int? padreId);

    
}
