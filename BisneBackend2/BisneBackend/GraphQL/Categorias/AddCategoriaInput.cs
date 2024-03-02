using BisneBackend.Data.Models;

namespace BisneBackend.GraphQL.Categorias
{
    public record AddCategoriaInput(string nombre, int? padreId);

    
}
