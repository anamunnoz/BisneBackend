using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisneBackend.Data.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        
        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        public string? nombre { get; set; }

        public int? padreId { get; set; }
        public virtual Categoria? padre { get; set; }

        public ICollection<OfertaCategoria> OfertaCategorias { get; set; }= new List<OfertaCategoria>();

    }
}
