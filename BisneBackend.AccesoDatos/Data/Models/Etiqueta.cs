using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisneBackend.AccesoDatos.Data.Models
{
    [Table("Etiqueta")]
    public class Etiqueta
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        public string? nombre { get; set; }

    }
}
