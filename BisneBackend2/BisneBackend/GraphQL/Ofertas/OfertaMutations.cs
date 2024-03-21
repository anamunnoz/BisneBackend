using BisneBackend.Data;
using BisneBackend.Data.Extensions;
using BisneBackend.Data.Models;

namespace BisneBackend.GraphQL.Ofertas
{
    [ExtendObjectType("Mutation")]
    public class OfertaMutations
    {
        [UseApplicationDbContext]
        public async Task<AddOfertaPayload> AddOfertaAsync(
           AddOfertaInput input,
           [ScopedService] MyDbContext context,
           CancellationToken cancellationToken)
        {
            var oferta= new Oferta
            {
                nombre = input.nombre,
                descripcion = input.descripcion,
                precio = input.precio,
                ImageURL = input.imageURL,
                tiendaId = input.tiendaId
            };

            context.Ofertas.Add(oferta);
            await context.SaveChangesAsync(cancellationToken);

            return new AddOfertaPayload(oferta);
        }

        [UseApplicationDbContext]
        public async Task<UpdateOfertaPayload> UpdateOfertaAsync(
           UpdateOfertaInput input,
           [ScopedService] MyDbContext context,
           CancellationToken cancellationToken)
        {
            Oferta oferta = await context.Ofertas.FindAsync(input.Id);
            if (input.descripcion != null) oferta.descripcion = input.descripcion;
            if (input.imageURL != null) oferta.ImageURL = input.imageURL;
            if(input.nombre != null) oferta.nombre = input.nombre;
            if (input.precio != null) oferta.precio = input.precio;

            await context.SaveChangesAsync(cancellationToken);

            return new UpdateOfertaPayload(oferta);
        }

    }
}
