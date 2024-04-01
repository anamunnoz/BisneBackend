using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BisneBackend.AccesoDatos.Data.Models
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

        [MaxLength(50)]
        [Display(Name = "Direccion")]
        public string? direccion { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Provincia")]
        public string? provincia { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Municipio")]
        public string? municipio { get; set; }

        [Required]
        [MaxLength(1000)]
        [Display(Name = "Descripcion")]
        public string? descripcion { get; set; }

        [MaxLength(150)]
        [Display(Name = "Horario")]
        public string? horario { get; set; }

        [Display(Name = "NumeroWhatsapp")]
        public string? numeroWhatsapp { get; set; }

        [Display(Name = "NumeroTelefono")]
        public string? numeroTelefono { get; set; }

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
