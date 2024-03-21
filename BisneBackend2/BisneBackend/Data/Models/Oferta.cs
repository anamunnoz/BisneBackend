using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisneBackend.Data.Models
{
    [Table("Oferta")]

    public class Oferta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        public string? nombre { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Descripcion")]
        public string? descripcion { get; set; }

        [Required]
        public int? precio { get; set; }
        //[Required]
        //public int cantidad { get; set; }
        //public int? descuento { get; set; }

        [Required]
        public int tiendaId { get; set; }

        [Required]
        public string? ImageURL { get; set; }

        [ForeignKey("tiendaId")]
        public Tienda? tienda { get; set; }

        public ICollection<OfertaCategoria> OfertaCategorias { get; set; }=new List<OfertaCategoria>();
        public ICollection<FacturaOferta> FacturaOfertas { get; set; }=new List<FacturaOferta>();
        public ICollection<UsuarioOfertaValoracion> usuarioOfertaValoraciones { get; set; } = new List<UsuarioOfertaValoracion>();
        public ICollection<UsuarioOfertaComentario> usuarioOfertaComentarios { get; set; } = new List<UsuarioOfertaComentario>();
    }
}
