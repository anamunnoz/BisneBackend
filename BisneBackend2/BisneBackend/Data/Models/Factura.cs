using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisneBackend.Data.Models
{
    [Table("Factura")]
    public class Factura
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Fecha")]
        public DateOnly fecha { get; set; }

        
        [MaxLength(100)]
        [Display(Name = "Direccion")]
        public string? direccion_envio { get; set; }

        [Required]
        public int usuarioId { get; set; }

        [ForeignKey("usuarioId")]
        public Usuario_Registrado? usuario { get; set; }

        public ICollection<FacturaOferta> FacturaOfertas { get; set; }=new List<FacturaOferta>();

    }
}
