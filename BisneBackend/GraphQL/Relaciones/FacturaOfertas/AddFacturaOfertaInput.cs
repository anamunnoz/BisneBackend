using BisneBackend.AccesoDatos.Data.Models;

namespace BisneBackend.GraphQL.Relaciones.FacturaOfertas
{
    public record AddFacturaOfertaInput([property: ID(nameof(Oferta))] int ofertaId,
        [property: ID(nameof(Factura))] int facturaId,
        double montototal,
        double cantidad
        
        );
    
}
