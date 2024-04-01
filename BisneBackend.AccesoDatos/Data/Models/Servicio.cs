using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BisneBackend.AccesoDatos.Data.Models
{
    [Table("Servicio")]
    public class Servicio: Oferta
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Horario")]
        public string? horario { get; set; }
    }
}
