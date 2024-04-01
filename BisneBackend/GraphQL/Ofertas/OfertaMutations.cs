using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;

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
                tiendaId = input.tiendaId,
                categoriaId=input.categoriaId,
                etiquetaId=input.etiquetaId
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
            if (input.categoriaId != null) oferta.categoriaId = (int)input.categoriaId;
            if (input.etiquetaId != null) oferta.etiquetaId = (int)input.etiquetaId;


            await context.SaveChangesAsync(cancellationToken);

            return new UpdateOfertaPayload(oferta);
        }

        [UseApplicationDbContext]
        public async Task<AddOfertaPayload> DeleteOfertaAsync(
            [ID(nameof(Oferta))] int id,
            [ScopedService] MyDbContext context)
        {
            var oferta = await context.Ofertas.FindAsync(id);
            if (oferta == null)
            {
                throw new Exception($"No se encontró la oferta con el id {id}");
            }

            context.Ofertas.Remove(oferta);
            await context.SaveChangesAsync();

            return new AddOfertaPayload(oferta);
        }

    }
}
