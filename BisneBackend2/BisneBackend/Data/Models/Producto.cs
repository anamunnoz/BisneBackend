using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisneBackend.Data.Models
{
    [Table("Prodcuto")]
    public class Producto: Oferta
    {

        [MaxLength(20)]
        [Display(Name = "Marca")]
        public string? marca { get; set; }

        [Display(Name = "Volumen")]
        public double volumen { get; set; }

        [Display(Name = "Peso")]
        public double peso { get; set; }

        [Required]
        public string? ImageURL { get; set; }
    }
}
