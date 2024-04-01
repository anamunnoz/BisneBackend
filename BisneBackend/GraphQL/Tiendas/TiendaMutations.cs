using BisneBackend.AccesoDatos.Data;
using BisneBackend.AccesoDatos.Data.Extensions;
using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Tiendas
{
    [ExtendObjectType("Mutation")]
    public class TiendaMutations
    {
        [UseApplicationDbContext]
        public async Task<AddTiendaPayload> AddTiendaAsync(
            AddTiendaInput input,
            [ScopedService] MyDbContext context,
            CancellationToken cancellationToken)
        {
            var admin= new AdministradordeTienda { Id=input.administradorId };
            context.Administradordes.Add(admin);
            await context.SaveChangesAsync(cancellationToken);

            var tienda = new Tienda
            {
                nombre  = input.nombre,
                descripcion = input.descripcion,
                horario = input.horario,
                numeroWhatsapp = input.numeroWhatsapp,
                numeroTelefono = input.numeroTelefono,
                usuarioTelegram = input.usuarioTelegram,
                linkFacebook = input.linkFacebook,
                linkInstagram = input.linkInstagram,
                provincia = input.provincia,
                municipio = input.municipio,
                direccion = input.direccion,
                linkExtra = input.linkExtra,
                ImageURL = input.urlImagen,

                administradorId = input.administradorId    
            };

            context.Tiendas.Add(tienda);
            await context.SaveChangesAsync(cancellationToken);

            return new AddTiendaPayload(tienda);
        }

        [UseApplicationDbContext]
        public async Task<UpdateTiendaPayload> UpdateTiendaAsync(
            UpdateTiendaInput input,
            [ScopedService] MyDbContext context,
            CancellationToken cancellationToken)
            {
                Tienda tienda = await context.Tiendas.FindAsync(input.Id);
                if (input.direccion != null) tienda.direccion = input.direccion;
                if (input.descripcion != null) tienda.descripcion = input.descripcion;
                if (input.horario != null) tienda.horario = input.horario;
                if (input.numeroWhatsapp != null) tienda.numeroWhatsapp = input.numeroWhatsapp;
                if (input.numeroTelefono != null) tienda.numeroTelefono = input.numeroTelefono;
                if (input.usuarioTelegram != null) tienda.usuarioTelegram = input.usuarioTelegram;
                if (input.linkFacebook != null) tienda.linkFacebook = input.linkFacebook;
                if (input.linkInstagram != null) tienda.linkInstagram = input.linkInstagram;
                if (input.linkExtra != null) tienda.linkExtra = input.linkExtra;
                if (input.urlImagen != null) tienda.ImageURL = input.urlImagen;
                
                await context.SaveChangesAsync(cancellationToken);

                return new UpdateTiendaPayload(tienda);
            }

    }
}
