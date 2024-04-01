using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Models;
using BisneBackend.AccesoDatos.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BisneBackend.GraphQL.Etiquetas
{
    [ExtendObjectType("Mutation")]
    public class EtiquetaMutations
    {
        [UseApplicationDbContext]
        public async Task<AddEtiquetaPayload> AddEtiquetaAsync(
            AddEtiquetaInput input,
            [ScopedService] MyDbContext context)
        {
            var etiquetas = await context.Etiquetas.ToListAsync();
            foreach(var x in etiquetas)
            {
                if (x.nombre.ToLower() == input.nombre.ToLower()) return new AddEtiquetaPayload(x);
                
            }

            var etiqueta = new Etiqueta
            {
                nombre = input.nombre,

            };
            context.Etiquetas.Add(etiqueta);
            await context.SaveChangesAsync();

            return new AddEtiquetaPayload(etiqueta);
        }
       
    }
}
