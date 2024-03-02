using BisneBackend.GraphQL.Payloads;
using BisneBackend.GraphQL.Inputs;
using BisneBackend.Data;
using BisneBackend.Data.Models;
using BisneBackend.Data.Extensions;

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
                padreId = input.padreId,
         

            };
            context.Categorias.Add(categoria);
            await context.SaveChangesAsync();
            

            return new AddCategoriaPayload(categoria);
        }
        /*
         [UseApplicationDbContext]
        public async Task<AddOfertaPayload> AddOfertaAsync(
            AddOfertaInput input,
            [ScopedService] MyDbContext context)
        {
            var oferta = new Oferta
            {
                nombre = input.nombre,
                descripcion = input.descripcion,
                precio = input.precio,
                cantidad = input.cantidad,
                tiendaId = input.tiendaID,
                descuento = input.descuento
            };
            context.Ofertas.Add(oferta);
            await context.SaveChangesAsync();
            
            return new AddOfertaPayload(oferta);
        }*/
    }
}
