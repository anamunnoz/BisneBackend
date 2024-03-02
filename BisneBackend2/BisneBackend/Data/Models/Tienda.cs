using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisneBackend.Data.Models
{
    [Table("Tienda")]
    public class Tienda
    {
        [Key]
      
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        public string? nombre { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Descripcion")]
        public string? descripcion { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Horario")]
        public string? horario { get; set; }

        [Display(Name = "NumeroWhatsapp")]
        public int? numeroWhatsapp { get; set; }

        [Display(Name = "NumeroTelefono")]
        public int? numeroTelefono { get; set; }

        [MaxLength(20)]
        [Display(Name = "UsuarioTelegram")]
        public string? usuarioTelegram { get; set; }

        [MaxLength(200)]
        [Display(Name = "LinkFacebook")]
        public string? linkFacebook { get; set; }

        [MaxLength(200)]
        [Display(Name = "LinkInstagram")]
        public string? linkInstagram { get; set; }

        [MaxLength(200)]
        [Display(Name = "LinkExtra")]
        public string? linkExtra { get; set; }

        public string? ImageURL { get; set; }

        [Required]
        public int administradorId { get; set; }

        [ForeignKey("administradorId")]
        public AdministradordeTienda? administrador { get; set; }

        public IList<Oferta> ofertas { get; set; } = new List<Oferta>();
        public IList<UsuarioTiendaFav> usuarioTiendaFavs { get; set; } = new List<UsuarioTiendaFav>();
        public IList<UsuarioTiendaValoracion> usuarioTiendaValoraciones { get; set; }= new List<UsuarioTiendaValoracion>();
        public IList<UsuarioTiendaComentario> usuarioTiendaComentarios { get; set; }= new List<UsuarioTiendaComentario>();





    }
}
