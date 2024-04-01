using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisneBackend.AccesoDatos.Data.Models
{
    public class FacturaOferta
    {

        [Required]
        public int ofertaId { get; set; }

        [ForeignKey("ofertaId")]
        public Oferta? oferta { get; set; }


        [Required]
        public int facturaId { get; set; }

        [ForeignKey("facturaId")]
        public Factura? factura { get; set; }

        [Required]
        public double cantidad { get; set; }
        [Required]
        public double monto_total { get; set; }
    }
}
