using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisneBackend.Data.Models
{
    public class UsuarioOfertaValoracion
    {
        [Required]
        public int usuarioId { get; set; }

        [ForeignKey("usuarioId")]
        public Usuario_Registrado? usuario { get; set; }


        [Required]
        public int ofertaId { get; set; }

        [ForeignKey("ofertaId")]
        public Oferta? oferta { get; set; }

        [Required]
        public int valoracion { get; set; }
    }
}
