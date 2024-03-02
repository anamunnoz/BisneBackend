using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisneBackend.Data.Models
{
    [Table("UsuarioRegistrado")]
    public class Usuario_Registrado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        public string? nombre { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Correo")]
        public string? correo { get; set; }

        [Required]
        [MaxLength(12)]
        [Display(Name = "Password")]
        public string? password { get; set; }

        public ICollection<Factura> facturas { get; set; } = new List<Factura>();
        public ICollection<UsuarioIp> UsuarioIps { get; set; } = new List<UsuarioIp>();
        public ICollection<UsuarioTiendaFav> usuarioTiendaFavs { get; set; }= new List<UsuarioTiendaFav>();
        public ICollection<UsuarioTiendaValoracion> usuarioTiendaValoraciones { get; set; }= new List<UsuarioTiendaValoracion>();

        public ICollection<UsuarioTiendaComentario> usuarioTiendaComentarios { get; set; }= new List<UsuarioTiendaComentario>();

        public ICollection<UsuarioOfertaValoracion> usuarioOfertaValoraciones { get; set; }= new List<UsuarioOfertaValoracion>();

        public ICollection<UsuarioOfertaComentario> usuarioOfertaComentarios { get; set; }= new List<UsuarioOfertaComentario>();

    }
}
