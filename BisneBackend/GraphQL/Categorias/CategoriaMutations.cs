using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.AccesoDatos.Data.Extensions;

namespace BisneBackend.GraphQL.Categorias
{
    [ExtendObjectType("Mutation")]
    public class CategoriaMutations
    {
        [UseApplicationDbContext]
        public async Task<AddCategoriaPayload> AddCategoriaAsync(
            AddCategoriaInput input,
            [ScopedService] MyDbContext context)
        {
            var categoria = new Categoria
            {
                nombre = input.nombre,
            };
            
            context.Categorias.Add(categoria);
            await context.SaveChangesAsync();
           
            return new AddCategoriaPayload(categoria);
        }
    }
}
