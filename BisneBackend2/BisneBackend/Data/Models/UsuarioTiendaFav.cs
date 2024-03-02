using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisneBackend.Data.Models
{
    public class UsuarioTiendaFav
    {
        [Required]
        public int usuarioId { get; set; }

        [ForeignKey("usuarioId")]
        public Usuario_Registrado? usuario { get; set; }


        [Required]
        public int tiendaId { get; set; }

        [ForeignKey("tiendaId")]
        public Tienda? tienda { get; set; }
    }
}
