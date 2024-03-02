using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisneBackend.Data.Models
{
    public class OfertaCategoria
    {
        [Required]
        public int ofertaId { get; set; }

        [ForeignKey("ofertaId")]
        public Oferta? oferta { get; set; }


        [Required]
        public int categoriaId { get; set; }

        [ForeignKey("categoriaId")]
        public Categoria? categoria { get; set; }

    }
}
